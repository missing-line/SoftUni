namespace TheTankGame.Tests
{
    using NUnit.Framework;
    //using TheTankGame.Entities.Miscellaneous;
    //using TheTankGame.Entities.Parts;
    //using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void Sould_Be_Correct()
        {

            Vanguard vanguard = new Vanguard("SA - 203", 100, 300, 1000, 450, 2000, new VehicleAssembler());
            Revenger revenger = new Revenger("AKU", 1000, 1000, 1000, 1000, 1000, new VehicleAssembler());

            ArsenalPart arsenal = new ArsenalPart("Cannon-KA2", 300, 500, 450);
            ShellPart shell = new ShellPart("Shields-PI1", 200, 1000, 750);

            vanguard.AddArsenalPart(arsenal);
            revenger.AddShellPart(shell);

            string actual1 = vanguard.ToString();
            string expected1 = "Vanguard - SA - 203\r\nTotal Weight: 400.000\r\nTotal Price: 800.000\r\nAttack: 1450\r\nDefense: 450\r\nHitPoints: 2000\r\nParts: Cannon-KA2";

            string actual2 = revenger.ToString();
            string expected2 = "Revenger - AKU\r\nTotal Weight: 1200.000\r\nTotal Price: 2000.000\r\nAttack: 1000\r\nDefense: 1750\r\nHitPoints: 1000\r\nParts: Shields-PI1";

            Assert.That(actual1, Is.EqualTo(expected1));
            Assert.That(actual2, Is.EqualTo(expected2));

           // Assert.That(vanguard.TotalAttack,Is.EqualTo(1450));
           // Assert.That(vanguard.TotalDefense,Is.EqualTo(450));
           // Assert.That(vanguard.TotalPrice,Is.EqualTo(800));
           // Assert.That(vanguard.TotalWeight,Is.EqualTo(400));
           // Assert.That(vanguard.TotalHitPoints,Is.EqualTo(2000));
           //// Assert.That(vanguard.Parts,Is.EqualTo(2000));
        }
    }
}

