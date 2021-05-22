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
            //Assert
            

            //Act

            //assert
        }
    }
}
