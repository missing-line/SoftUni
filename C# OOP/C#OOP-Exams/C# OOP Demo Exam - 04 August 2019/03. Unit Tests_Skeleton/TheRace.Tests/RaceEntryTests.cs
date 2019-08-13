using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Initialization_Correct_UnitMotorcycle()
        {
            var unit = new UnitMotorcycle("OPA", 46, 100);

            Assert.That(unit.Model, Is.EqualTo("OPA"));
            Assert.That(unit.HorsePower, Is.EqualTo(46));
            Assert.That(unit.CubicCentimeters, Is.EqualTo(100));
        }

        [Test]
        public void Shoud_Initialization_Correct_RaceEntry()
        {
            var race = new RaceEntry();

            Assert.That(race.Counter,Is.EqualTo(0));
        }

        [Test]
        public void Shoud_AddRider_Correct()
        {
            var unit = new UnitMotorcycle("OPA", 46, 100);
            var rider = new UnitRider("Rider", unit);
            var race = new RaceEntry();

            string actual = race.AddRider(rider);

            Assert.That(actual,Is.EqualTo("Rider Rider added in race."));
        }

        [Test]
        public void Shoud_Throw_InvalidOperationException_Rider_Is_Null()
        {
            UnitRider rider = null;

            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
                    race.AddRider(rider),
                    "Rider cannot be null.");
        }

        [Test]
        public void Shoud_Throw_InvalidOperationException_ExistingRider()
        {
            var unit = new UnitMotorcycle("OPA", 46, 100);
            var rider = new UnitRider("Rider", unit);
            var race = new RaceEntry();
            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
                    race.AddRider(rider), 
                    "Rider Rider is already added.");

        }

        [Test]
        public void Shoud_CalculateAverageHorsePower_Correct()
        {
            var unit = new UnitMotorcycle("First", 46, 100);
            var unitSecond = new UnitMotorcycle("Second", 46, 100);
            var unitTh = new UnitMotorcycle("Third", 46, 100);

            var rider = new UnitRider("Rider", unit);       
            var riderSecond = new UnitRider("Rider1", unitSecond);
            var riderTh = new UnitRider("Rider2", unitSecond);

            var race = new RaceEntry();
            race.AddRider(rider);
            race.AddRider(riderSecond);
            race.AddRider(riderTh);

            double actual = race.CalculateAverageHorsePower();

            Assert.That(actual, Is.EqualTo(46));              
        }

        [Test]
        public void Shoud_InvalidOperationException_CalculateAverageHorsePower()
        {
            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
                   race.CalculateAverageHorsePower(), 
                   "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void Shoud_Initialization_Correct_UnitRider()
        {
            var unit = new UnitMotorcycle("OPA", 46, 100);
            var rider = new UnitRider("Rider", unit);

            Assert.That(rider.Name, Is.EqualTo("Rider"));
            Assert.That(rider.Motorcycle.Model, Is.EqualTo("OPA"));
            Assert.That(rider.Motorcycle.HorsePower, Is.EqualTo(46));
            Assert.That(rider.Motorcycle.CubicCentimeters, Is.EqualTo(100));
        }

        [Test]
        public void Shoud_Throw_ArgumentNullException_With_Null_Name()
        {
            var unit = new UnitMotorcycle("OPA", 46, 100);
            

            Assert.Throws<ArgumentNullException>(()
                => new UnitRider(null, unit),
                "Name cannot be null!");
        }
    }
}