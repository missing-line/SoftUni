using Travel.Core.Controllers;
using Travel.Entities;
using Travel.Entities.Airplanes;
using Travel.Entities.Items;

namespace Travel.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class FlightControllerTests
    {


        [Test]
        public void Test1()
        {

            var passenger = new[]
            {
               new Passenger("Pesho1"),
               new Passenger("Ivan2"),
               new Passenger("Ivan3"),
               new Passenger("Ivan4"),
               new Passenger("Ivan5"),
               new Passenger("Ivan6"),
            };
            var airplane = new LightAirplane();

            foreach (var i in passenger)
            {
                airplane.AddPassenger(i);
            }

            var trip = new Trip("Sofia", "London", airplane);

            var airport = new Airport();

            airport.AddTrip(trip);

            var flightController = new FlightController(airport);


            var bag1 = new Bag(passenger[1], new[] { new CellPhone() });


            passenger[1].Bags.Add(bag1);

            var trip2 = new Trip("Sofia", "Plovdiv", airplane);
            trip2.Complete();
            airport.AddTrip(trip2); 

            string actual = flightController.TakeOff();

            string expected = "SofiaLondon1:\r\nOverbooked! Ejected Ivan2\r\nConfiscated 1 bags ($700)\r\nSuccessfully transported 5 passengers from Sofia to London.\r\nConfiscated bags: 1 (1 items) => $700";

            Assert.That(actual, Is.EqualTo(expected).NoClip);
            Assert.That(trip.IsCompleted,Is.True);
        }      

    }
}
