using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TopFive.Models;

namespace TopFive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> restaurantList = new List<string>();

            foreach (Restaurant r in Restaurant.GetRestaurants())
            {
                if (r.FavoriteDish == null)
                { 
                    r.FavoriteDish = "It's all good!";
                }
                string phone = r.PhoneNumber.ToString();
                string area = phone.Substring(0, 3);
                string major = phone.Substring(3, 3);
                string minor = phone.Substring(6);
                string formatted = string.Format("{0}-{1}-{2}", area, major, minor);
                r.PhoneNumber = formatted;
                restaurantList.Add($"#{r.RestaurantRanking}, Restaurant Name: {r.RestaurantName}, Best Dish: {r.FavoriteDish}, Address: {r.Address}, Phone: {r.PhoneNumber}, Website: {r.Website}");
            }

            return View(restaurantList);
        }

        public IActionResult OtherList()
        {
            return View(RestaurantStorage.Restaurants);
        }

        [HttpGet]
        public IActionResult NewSubmit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewSubmit(OtherRestaurant newRestuarant)
        {
            RestaurantStorage.AddNewRestaurant(newRestuarant);
            return View("OtherList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
