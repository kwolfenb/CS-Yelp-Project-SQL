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
    }
}
