using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Yelp.Models;

namespace Yelp.Controllers
{
    public class CuisineController : Controller
    {

        [HttpGet("/cuisine/index")]
        public ActionResult Index()
        {
            List<Cuisine> allCuisines = Cuisine.GetAll();
            return View(allCuisines);   
        }   

        [HttpPost("/cuisine/index")]
        public ActionResult Create(string cuisineName)
        {
           Cuisine myCuisine = new Cuisine(cuisineName);
           myCuisine.Save();
           List<Cuisine> allCuisines = Cuisine.GetAll();
           return View("Index", allCuisines);
        }  

        [HttpGet("/cuisine/new")]
        public ActionResult New()
        {
        List<Cuisine> allCuisines = Cuisine.GetAll(); 
        return View(allCuisines);   
        }

        [HttpGet("/cuisine/show/{cuisineId}")]
        public ActionResult Show(int cuisineId)
        {
            Cuisine newCuisine = Cuisine.FindById(cuisineId);
            List<Restaurant> restaurantsByCuisine = Restaurant.FindByCuisineId(cuisineId);
            Dictionary<string, object> model = new Dictionary<string, object>{};
            model.Add("cuisine", newCuisine);
            model.Add("restaurantList", restaurantsByCuisine);
            return View(model);   
        }

    }
}
