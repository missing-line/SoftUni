namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
       [Test]
       public void Shoud_Initialization_Correct_Astronaut()
        {
            var astronaut = new Astronaut("Opa", 2.2);

            Assert.That(astronaut.Name, Is.EqualTo("Opa"));
            Assert.That(astronaut.OxygenInPercentage, Is.EqualTo(2.2));
        }
    
        [Test]
        public void Shoud_Initialization_Spaceship_Correct()
        {
            var spaceship = new Spaceship("test", 3);

            Assert.That(spaceship.Capacity,Is.EqualTo(3));
            Assert.That(spaceship.Name,Is.EqualTo("test"));
            Assert.That(spaceship.Count,Is.EqualTo(0));
        }

        [Test]
        public void Shoud_Throw_ArgumentNullException_With_Invalid_Name_Setter()
        {
            string name = "";
            Assert.Throws<ArgumentNullException>(() =>
            new Spaceship(name, 3),
            "Invalid spaceship name!");
        }

        [Test]
        public void Shoud_Throw_ArgumentException_With_Capacity_Setter()
        {
            Assert.Throws<ArgumentException>(() =>
            new Spaceship("Opa", -1),
           "Invalid capacity!");
        }

        [Test]
        public void Shoud_Add_Correct()
        {
            var astronaut = new Astronaut("Opa", 2.2);
            var spaceship = new Spaceship("test", 3);
            spaceship.Add(astronaut);
            Assert.That(spaceship.Count, Is.EqualTo(1));
        }

        [Test]
        public void Shoud_Throw_InvalidOperationException_Add_FullShip()
        {
            var astronaut1 = new Astronaut("Opa1", 2.21);
            var astronaut2 = new Astronaut("Opa2", 2.22);
            var astronaut3 = new Astronaut("Opa3", 2.23);
            var astronaut4 = new Astronaut("Opa4", 2.24);

            var spaceship = new Spaceship("test", 2);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);


            Assert.Throws<InvalidOperationException>(()
                => spaceship.Add(astronaut4),
               "Spaceship is full!");
        }

        [Test]
        public void Shoud_Throw_InvalidOperationException_AlreadyIsAdd()
        {
            var astronaut1 = new Astronaut("Opa1", 2.21);
            var astronaut2 = new Astronaut("Opa2", 2.22);
           

            var spaceship = new Spaceship("test", 3);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);


            Assert.Throws<InvalidOperationException>(()
                => spaceship.Add(astronaut2),
               $"Astronaut {astronaut2.Name} is already in!");

        }

        [Test]
        public void Shoud_Remove_FromCollection_Correct_True()
        {
            var astronaut1 = new Astronaut("Opa1", 2.21);
            var astronaut2 = new Astronaut("Opa2", 2.22);


            var spaceship = new Spaceship("test", 2);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);

            bool actual = spaceship.Remove("Opa1");

            Assert.That(actual, Is.EqualTo(true));
        }

        [Test]
        public void Shoud_Remove_FromCollection_Correct_False()
        {
            var astronaut1 = new Astronaut("Opa1", 2.21);
            var astronaut2 = new Astronaut("Opa2", 2.22);


            var spaceship = new Spaceship("test", 2);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);

            bool actual = spaceship.Remove("Opa3");

            Assert.That(actual, Is.EqualTo(false));
        }
    }
}