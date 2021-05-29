using MAL_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

namespace UnitTesting_UnitTests
{
    [TestClass]
    public class MALTest
    {
        [TestMethod]
        public void Toevoegen_Van_Lijst()
        {
            //Arrange
            Collection collection = new Collection();

            //Act
            collection.name = "Test1";

            //assert
            Assert.AreEqual("Test1", collection.name);
        }

        [TestMethod]
        public void Verwijderen_Van_lijst()
        {
            //Arrange
            Collection collection = new Collection();
            collection.name = "Test2";

            //Act
            DatabaseOperations.VerwijderenLijst(collection);

            //assert
            Assert.AreEqual("Test2", collection.name);
        }

        [TestMethod]
        public void Toevoegen_Nieuwe_Anime()
        {
            //Arrange
            Anime anime = new Anime();

            //Act
            DatabaseOperations.ToevoegenNieuweAnime(anime);
            anime.name = "Test3";
            anime.rating = 1;
            anime.status = "Going";
            anime.type = "TV";
            anime.duration = int.Parse("10");
            anime.episodes = 10;

            //assert
            Assert.AreEqual("Test3", anime.name);
        }

        [TestMethod]
        public void Verwijderen_Anime()
        {
            //Arrange
            Anime anime = new Anime();

            //Act
            DatabaseOperations.VerwijderenAnime(anime);
            anime.name = "Test4";
            anime.rating = 1;
            anime.status = "Going";
            anime.type = "TV";
            anime.duration = int.Parse("10");
            anime.episodes = 10;

            //Assert
            Assert.AreEqual("Test4", anime.name);
        }
    }
}