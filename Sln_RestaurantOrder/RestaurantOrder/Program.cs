using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RestaurantClasses;

namespace RestaurantOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call Order Menu
            RestaurantMenu oRestMenu = new RestaurantMenu(Period.setPeriods(), Dish.setDish());   
        }
    }
}
