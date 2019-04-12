namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Energy;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ModuleContainerTests
    {


        [Test]
        public void Should_Be_Initialize_Correct()
        {
            ModuleContainer container = new ModuleContainer(10);
            container.AddEnergyModule(new CryogenRod(1, 100));
            container.AddAbsorbingModule(new HeatProcessor(2, 200));


            int actula = container.ModulesByInput.Count;

            Assert.That(actula, Is.EqualTo(2));
        }

        [Test]
        public void Should_Be_TotalHeatAbsorbing_Retturn_Correct()
        {
            ModuleContainer container = new ModuleContainer(10);
            container.AddEnergyModule(new CryogenRod(1, 100));
            container.AddAbsorbingModule(new HeatProcessor(2, 200));

            long actual = container.TotalHeatAbsorbing;

            Assert.That(actual, Is.EqualTo(200));
        }

        [Test]
        public void Should_Be_Retturn_Correct_TotalEnergy()
        {
            ModuleContainer container = new ModuleContainer(10);
            container.AddEnergyModule(new CryogenRod(1, 100));
            container.AddAbsorbingModule(new HeatProcessor(2, 200));

            long actual = container.TotalEnergyOutput;

            Assert.That(actual, Is.EqualTo(100));
        }

        [Test]
        public void Should_Be_Remove_Correct()
        {
            var container = new ModuleContainer(1);
            container.AddEnergyModule(new CryogenRod(1, 50));
            container.AddAbsorbingModule(new CooldownSystem(2, 100));
            container.AddAbsorbingModule(new HeatProcessor(3, 100));

            int actual = container.ModulesByInput.Count;

            Assert.That(actual, Is.EqualTo(1));
        }
    }
}
