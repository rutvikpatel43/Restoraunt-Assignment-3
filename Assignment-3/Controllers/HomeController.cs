using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_3.Models;

/**
 * Authors:Rutvik Patel, Himanshu Patel
 * This page deals with view details the dish to the end user
 * It has view for each of the function
 */

namespace Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        DishesModel db = new DishesModel();
        public ActionResult Index()
        {
            List<String> dish = db.Dish.Select(w => w.Type).Distinct().ToList();
            return View(dish);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Item(string dishName)
        {
            Dishes dish = (from u in db.Dish
                           where u.DishName == dishName
                           select u).FirstOrDefault();
            return View(dish);
        }

        public ActionResult Menu(string type)
        {
            List<Dishes> dish = db.Dish.Where(w => w.Type == type).ToList();
            return View(dish);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}