using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Yelp.Models;

namespace Yelp.Controllers
{
    public class RestaurantController : Controller
    {
     [HttpGet("/restaurant/new")]
     public ActionResult New()
     {
      return View();   
     }   



    [HttpPost("/restaurant/index")]
     public ActionResult Index(string restaurantName,string restaurantAddress, string restaurantPhone, int restaurantCuisine)
     {
     Restaurant myRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhone, restaurantCuisine);
     myRestaurant.Save();
     List<Restaurant> allRestaurants = Restaurant.GetAll();
     return View(allRestaurants);
     }

    [HttpGet("/restaurant/index")]
    public ActionResult Main()
    {
        List<Restaurant> allRestaurants = Restaurant.GetAll();
        return View("Index", allRestaurants);
    }
    
    [HttpGet("/restaurant/show/{restaurantId}")]
    public ActionResult Show(int restaurantId)
    {
        Restaurant resultRestaurant = Restaurant.FindById(restaurantId);
        return View(resultRestaurant);
    }
     
    }
}



