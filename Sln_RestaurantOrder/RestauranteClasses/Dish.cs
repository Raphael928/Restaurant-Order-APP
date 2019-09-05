using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantClasses
{
    public class Dish
    {
        public string Description { get; set; }
        public int Id_Period { get; set; }
        public int Id_DishType { get; set; }
        public string Desc_DishType { get; set; }
        public bool More_Than_One { get; set; }

        public static List<Dish> setDish()
        {
            List<Dish> lstDish = new List<Dish>();

            //Morning
            lstDish.Add(new Dish() { Id_DishType = 1, Description = "Eggs", Id_Period = 1, Desc_DishType = "Entrée", More_Than_One = false }); //Id_Period - From ID Period List
            lstDish.Add(new Dish() { Id_DishType = 2, Description = "Toast", Id_Period = 1, Desc_DishType = "Side", More_Than_One = false });
            lstDish.Add(new Dish() { Id_DishType = 3, Description = "Coffee", Id_Period = 1, Desc_DishType = "Drink", More_Than_One = true });

            //Night
            lstDish.Add(new Dish() { Id_DishType = 1, Description = "Steak", Id_Period = 2, Desc_DishType = "Entrée", More_Than_One = false });
            lstDish.Add(new Dish() { Id_DishType = 2, Description = "Potato", Id_Period = 2, Desc_DishType = "Side", More_Than_One = true });
            lstDish.Add(new Dish() { Id_DishType = 3, Description = "Wine", Id_Period = 2, Desc_DishType = "Drink", More_Than_One = false });
            lstDish.Add(new Dish() { Id_DishType = 4, Description = "Cake", Id_Period = 2, Desc_DishType = "Dessert", More_Than_One = false });

            return lstDish;
        }
    }
}
