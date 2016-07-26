using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Image")]
        public string ThumbnailUrl { get; set; }
        // to give description to an item
        [Display(Name = "Dish Descriprtion")]
        [Required(ErrorMessage = "Description Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Invalid")]
        public string Description { get; set; }
        // dish name
        [Display(Name = "Dish Name")]
        [Required(ErrorMessage = "DishName Required")]
        public string DishName { get; set; }
        // price of dish
        [Display(Name = "Dish Price")]
        [Required(ErrorMessage = "Dishprice Required")]
        public decimal price { get; set; }
        

    }
}