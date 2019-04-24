namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;
        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void Initil_Should_Be_Correct()
        {
            Assert.That(softPark.Parking.Count, Is.EqualTo(12));
        }

        [Test]
        public void Should_ParkCar_Correct()
        {
            string actual = this.softPark.ParkCar("A1", new Car("opel", "032"));

            string expected = "Car:032 parked successfully!";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_ParkCar_Throw_ArgumentException_Invalid_Spot()
        {
            Assert.Throws<ArgumentException>(()
                => this.softPark.ParkCar("ZZ", new Car("opel", "032")),
                "Parking spot doesn't exists!");
        }

        [Test]
        public void Should_ParkCar_Throw_ArgumentException_Taken_Spot()
        {
            this.softPark.ParkCar("A1", new Car("opel", "032"));
            Assert.Throws<ArgumentException>(()
                => this.softPark.ParkCar("A1", new Car("troshka", "002")),
                "Parking spot is already taken!");
        }

        [Test]
        public void Should_ParkCar_Throw_InvalidOperationException_Car_Is_Parked()
        {
            this.softPark.ParkCar("A1", new Car("opel", "032"));

            Assert.Throws<InvalidOperationException>(()
                => this.softPark.ParkCar("B1", new Car("opel", "032")),
               "Car is already parked!");
        }

        [Test]
        public void Should_RemoveCar_Throw_ArgumentException_Invalid_Spot()
        {

            Assert.Throws<ArgumentException>(()
                => this.softPark.RemoveCar("ZZ", new Car("opel", "032")),
               "Parking spot doesn't exists!");
        }

        [Test]
        public void Should_RemoveCar_Throw_ArgumentException_Car_Dont_Exist_On_This_Spot()
        {
            //this.softPark.RemoveCar("B1", new Car("opel", "032"));

            Assert.Throws<ArgumentException>(()
                => this.softPark.RemoveCar("A1", new Car("opel", "032")),
               "Car for that spot doesn't exists!");
        }

        [Test]
        public void Should_RemoveCar_Correct()
        {
            Car car = new Car("opel", "032");         

            this.softPark.ParkCar("A1", car);

            string actual = this.softPark.RemoveCar("A1",  car);

            string expected = "Remove car:032 successfully!";

            Assert.That(actual,Is.EqualTo(expected));
        }
    }
}
