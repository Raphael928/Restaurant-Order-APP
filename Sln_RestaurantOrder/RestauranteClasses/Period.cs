using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantClasses
{
    public class Period
    {
        public string Description { get;  set; }
        public int ID { get; set; }

        public static List<Period> setPeriods()
        {
            List<Period> lstPeriod = new List<Period>();

            lstPeriod.Add(new Period() { Description = "Morning", ID = 1 });
            lstPeriod.Add(new Period() { Description = "Night", ID = 2 });

            return lstPeriod;

        }
    }

   
}
