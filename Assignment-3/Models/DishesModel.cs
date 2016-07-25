namespace Assignment_3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DishesModel : DbContext
    {
        public DishesModel()
            : base("name=DishesConnection")
        {
        }

        public DbSet<Dishes> Dish { get; set; }
    }
}
