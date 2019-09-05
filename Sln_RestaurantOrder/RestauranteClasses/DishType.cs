using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantClasses
{
    public class DishType
    {
        public int Id_DishType { get; set; }
        public string Description { get; set; }

        public static List<DishType> setDishtype()
        {
            List<DishType> lstDishType = new List<DishType>();

            lstDishType.Add(new DishType() { Description = "Entrée", Id_DishType = 1 });
            lstDishType.Add(new DishType() { Description = "Side", Id_DishType = 2 });
            lstDishType.Add(new DishType() { Description = "Drink", Id_DishType = 3 });
            lstDishType.Add(new DishType() { Description = "Dessert", Id_DishType = 4 });

            return lstDishType;

        }
    }
}
