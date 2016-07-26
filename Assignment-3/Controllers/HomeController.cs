using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_3.Models;
namespace Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        DishesModel db = new DishesModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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