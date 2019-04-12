// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;

    using System;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void Test()
        {
            Stage stage = new Stage();
            //--------------------------------//

            Guitar guitar = new Guitar();
            Drums drums = new Drums();
            Microphone microphone = new Microphone();


            var performar1 = new Performer("Pesho ", 1);
            performar1.AddInstrument(guitar);

            var performar2 = new Performer("Ivan", 2);
            performar2.AddInstrument(drums);

            var performar3 = new Performer("Gosho ", 3);
            performar3.AddInstrument(microphone);

            var set1 = new Short("Set1");
            var set2 = new Long("Set2");
            var set3 = new Medium("Set3");
            var set4 = new Medium("Set4");

            set1.AddPerformer(performar1);
            set2.AddPerformer(performar2);
            set3.AddPerformer(performar3);

            var song1 = new Song("Song1 ", new TimeSpan(0,5,0));
            var song2 = new Song("Song2 ", new TimeSpan(0,5,0));
            var song3 = new Song("Song3 ", new TimeSpan(0,5,0));

            set1.AddSong(song1);
            set2.AddSong(song2);
            set3.AddSong(song3);

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddSet(set3);
            stage.AddSet(set4);

            SetController setController = new SetController(stage);

            string actual = setController.PerformSets();

            string expected = "1. Set1:\r\n-- 1. Song1  (05:00)\r\n-- Set Successful\r\n2. Set2:\r\n-- 1. Song2  (05:00)\r\n-- Set Successful\r\n3. Set3:\r\n-- 1. Song3  (05:00)\r\n-- Set Successful\r\n4. Set4:\r\n-- Did not perform";
            Assert.That(actual, Is.EqualTo(expected));
        }    

        [Test]
        public void No_WearDown_Instruments()
        {
            Stage stage = new Stage();

            var performar1 = new Performer("Pesho", 19);

            performar1.AddInstrument(new Guitar());           

            var song1 = new Song("Song1 ", new TimeSpan(0, 1, 2));

            var set1 = new Long("Set1");

            set1.AddSong(song1);

            set1.AddPerformer(performar1);     

            stage.AddSet(set1);
            SetController setController = new SetController(stage);

            string actual = setController.PerformSets();
       
            Assert.That(performar1.Instruments.First().Wear,Is.EqualTo(40));
           
        }
    }
}
