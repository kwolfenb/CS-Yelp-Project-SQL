using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yelp.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Yelp.Tests
{
    [TestClass]
    public class CuisineTest : IDisposable
    { 
        public void Dispose()
        {
            Cuisine.ClearAll();
        }

        public CuisineTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=yelp_test;";
        }

        [TestMethod]
        public void Type_ReturnsTypesofCuisineClass_Type()
        {
            Cuisine newCuisine = new Cuisine("Sushi");
            Assert.AreEqual(typeof(Cuisine), newCuisine.GetType());
        }

        [TestMethod]
        public void GetAll_ReturnsListOfCuisines_List()
        {
            Cuisine cuisineOne = new Cuisine("Venitian");
            Cuisine cuisineTwo = new Cuisine("French");
            List<Cuisine> allCuisines = new List<Cuisine>{cuisineOne, cuisineTwo};
            cuisineOne.Save();
            cuisineTwo.Save();
            List<Cuisine> resultList = Cuisine.GetAll();
            CollectionAssert.AreEqual(allCuisines, resultList);
        }
    }
}       