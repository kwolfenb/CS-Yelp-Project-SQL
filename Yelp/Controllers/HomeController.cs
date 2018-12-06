using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Yelp.Models;

namespace Yelp.Controllers
{
    public class HomeController : Controller
    {
     [HttpGet("/")]
     public ActionResult Index()
     {
      return View();   
     }   
    }
}
