using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3.Models
{
    public class Dishes
    {
        // Dish Id primary Key
        public int Id { get; set;}
        // Specifics food or drink 
        public string Type { get; set; }
        // to display full sized image
        public string ImageUrl { get; set; }
        // to display thumbnail size image
        public string ThumbnailUrl { get; set; }
        // to give description to an item
        public string Description { get; set; }
        // dish name
        public string DishName { get; set; }
        // price of dish
        public decimal price { get; set; }
    }
}