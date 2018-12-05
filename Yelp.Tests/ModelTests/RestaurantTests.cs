using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yelp.Models;
using System;
using System.Collections.Generic;
 
namespace Yelp.Tests
{
    [TestClass]
    public class RestaurantTest : IDisposable
    { 
        public void Dispose()
        {
            Restaurant.DeleteAll();
        }

        public void ItemTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yelp_test;";
        }

        [TestMethod]
        public void Type_ReturnsTypesofRestaurantClass_Type()
        {
            Restaurant newRest = new Restaurant("BurgerQueen");
            Assert.AreEqual(typeof(Restaurant), newRest.GetType());
        }

        [TestMethod]
        public void Saves_SavestoRestaurantTabels_Method()
        {
            string name = "BurgerQueen";
            Restaurant newRest = new Restaurant("BurgerQueen","123 Main","223-2222","cuisine");
            newRest.Save();
            List<Restaurant> resultList = Restaurant.GetAll();
            Restaurant result = resultList[0];
            string resultName = result.GetName();

            Assert.AreEqual(name, resultName);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
        {
            //Arrange
            List<Restaurant> newList = new List<Restaurant> {};
            //Act
            List<Restaurant> result = Restaurant.GetAll();
            //Assert
            CollectionAssert.AreEqual(newList, result);
        }
    }
}
