namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    public class Tests
    {

        [Test]
        public void Shoud_Be_Initil_Correct()
        {
            Phone phone = new Phone("name", "ip");

            Assert.That(phone.Make, Is.EqualTo("name"));
            Assert.That(phone.Model, Is.EqualTo("ip"));
            Assert.That(phone.Count, Is.EqualTo(0));
        }

        [Test]
        public void Should_Be_AddContact_Correct()
        {
            Phone phone = new Phone("name", "ip");
            phone.AddContact("opa", "032");

            Assert.That(phone.Count, Is.EqualTo(1));
        }

        [Test]
        public void Throw_InvalidOperationException_With_ExistPerson()
        {
            Phone phone = new Phone("name", "ip");
            phone.AddContact("opa", "032");

            Assert.Throws<InvalidOperationException>(()
                => phone.AddContact("opa", "032"),
                "Person already exists!");
        }

        [Test]
        public void Should_Be_Calling_Correct()
        {
            //$"Calling {name} - {number}...";
            Phone phone = new Phone("name", "ip");
            phone.AddContact("opa", "032");

            string actual = phone.Call("opa");
            Assert.That(actual, Is.EqualTo("Calling opa - 032..."));
        }

        [Test]
        public void Throw_InvalidOperationException_Calling_To_UnexistPerson()
        {
            Phone phone = new Phone("name", "ip");

            Assert.Throws<InvalidOperationException>(()
                => phone.Call("opa"),
                "Person doesn't exists");
        }

        [Test]
        public void Shoukd_Be_Throw_ArgumentException_With_Invalid_NameAndModel_Set()
        {
            Assert.Throws<ArgumentException>(()
               => new Phone("", "opaaa"));

            Assert.Throws<ArgumentException>(()
               => new Phone("opaaaa", ""));
        }
    }
}