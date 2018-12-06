using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yelp.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Yelp.Tests
{
    [TestClass]
    public class RestaurantTest : IDisposable
    { 
        public void Dispose()
        {
            Restaurant.ClearAll();
        }

        public RestaurantTest()
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
            Restaurant newRest = new Restaurant("BurgerQueen","123 Main","223-2222",1);
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

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Restaurants()
        {
            //Arrange
            Restaurant restaurant1 = new Restaurant("Dominos", "123 Main St", "333-333-3333", 1);
            Restaurant restaurant2 = new Restaurant("Dominos", "123 Main St", "333-333-3333", 1);

            Assert.AreEqual(restaurant1, restaurant2);
        }

        [TestMethod]
        public void FindId_ReturnsTrueIfIdsAreTheSame_Int()
        {
            //Arrange
            Restaurant restaurant1 = new Restaurant("Dominos", "123 Main St", "333-333-3333", 1);
            restaurant1.Save();
            int resultId = restaurant1.GetId();
            Restaurant result = Restaurant.FindById(resultId);
            Assert.AreEqual(result, restaurant1);
        }
    }
}
