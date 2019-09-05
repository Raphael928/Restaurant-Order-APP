using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RestaurantClasses;

namespace RestaurantOrder
{
    public class RestaurantMenu
    {
        public class OptionsSelected
        {
            public int ID { get; set; }
            public string Description { get; set; }
        }

        public RestaurantMenu(List<Period> lstPeriod, List<Dish> lstDish)
        {
            string strMenu = "";
            string options;
            List<Dish> lstFindDish;
            List<DishType> lstDishType = new List<DishType>();
            lstDishType = DishType.setDishtype();

            //create a Menu
            foreach (Period oPeriod in lstPeriod)
            {
                if (strMenu == null)
                    strMenu = "Period - " + oPeriod.Description + Environment.NewLine;
                else
                    strMenu += Environment.NewLine + "Period - " + oPeriod.Description + Environment.NewLine;

                lstFindDish = lstDish.FindAll(
                    delegate (Dish oDish)
                    {
                        return oDish.Id_Period == oPeriod.ID;
                    }
                );

                foreach (Dish oDish in lstFindDish)
                {
                    strMenu += oDish.Id_DishType + "(" + lstDishType.Find(x => x.Id_DishType == oDish.Id_DishType).Description + ")" + " - " + oDish.Description + Environment.NewLine;
                }
            }

            Console.WriteLine("");
            Console.WriteLine(strMenu);
            Console.WriteLine(" Digit a period and numbers of dishes separated by comma (morning, 1, 2, 3): ");
            options = Console.ReadLine();

            Console.WriteLine("");

            //Process Order and return the resume of order
            IEnumerable<OptionsSelected> distinctOptions = ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);

            options = "";

            Console.WriteLine("output: " + ResumeOrder(distinctOptions));
        }

        public static List<OptionsSelected> ProcessOrder(string optionsSel, List<Period> lstPeriod, List<Dish> lstDish)
        {
            List<Period> lstFindPeriod = new List<Period>();
            List<Dish> lstFindDish = new List<Dish>();

            List<OptionsSelected> result = new List<OptionsSelected>();

            List<string> lstOptions = optionsSel.Trim().Split(',').ToList<string>();
            
            //Verify period selected
            foreach (string opt in lstOptions)
            {
                if (lstPeriod.Exists(x => x.Description.ToUpper() == opt.Trim().ToUpper()))
                {
                    lstFindPeriod = lstPeriod.FindAll(
                       delegate (Period oPeriod)
                       {
                           return oPeriod.Description.ToUpper() == opt.ToUpper();
                       }
                   );

                    lstOptions.Remove(opt.ToUpper());
                    break;
                }
            }

            if (lstFindPeriod.Count <= 0)
            {
                result.Add(new OptionsSelected() { ID = 0, Description = "Period not found!" });
                return result;
            }

            //Verify Dishes selected
            for (int i = 0; i < lstOptions.Count; i++)
            {
                if (lstOptions[i].Trim() == "")
                {
                    lstOptions[i] = "0";
                }

                lstFindDish = lstDish.FindAll(
                    delegate (Dish oDish)
                    {
                        return oDish.Id_Period == lstFindPeriod[0].ID && oDish.Id_DishType == Convert.ToInt32(lstOptions[i]);
                    }
                );

                int qtt_Op = 0;

                if (lstFindDish.Count > 0)
                {
                    //count Dishes selected
                    var q = from x in lstOptions
                            group x by x into g
                            let count = g.Count()
                            orderby count descending
                            select new { Value = g.Key, Count = count };

                    foreach (var x in q)
                    {
                        if (x.Value == lstOptions[i])
                        {
                            qtt_Op = x.Count;
                            break;
                        }
                    }

                    //Return dishes selected for period
                    if (lstFindDish[0].More_Than_One && qtt_Op > 1)
                    {
                        result.Add(new OptionsSelected() { ID = lstFindDish[0].Id_DishType, Description = lstFindDish[0].Description.ToString() + "(x" + qtt_Op.ToString() + ")" });
                    }
                    else if ((lstFindDish[0].More_Than_One) && (qtt_Op <= 1))
                    {
                        result.Add(new OptionsSelected() { ID = lstFindDish[0].Id_DishType, Description = lstFindDish[0].Description });
                    }
                    else if ((!lstFindDish[0].More_Than_One) && (qtt_Op <= 1))
                    {
                        result.Add(new OptionsSelected() { ID = lstFindDish[0].Id_DishType, Description = lstFindDish[0].Description });
                    }
                    else if ((!lstFindDish[0].More_Than_One) && (qtt_Op > 1))
                    {
                        result.Add(new OptionsSelected() { ID = lstFindDish[0].Id_DishType, Description = lstFindDish[0].Description });
                        result.Add(new OptionsSelected() { ID = lstFindDish[0].Id_DishType, Description = "error" });
                        // return result;
                    }
                    else
                    {
                        result.Add(new OptionsSelected() { ID = lstFindDish[0].Id_DishType, Description = "error" });
                        return result;
                    }
                }
                else
                {
                    result.Add(new OptionsSelected() { ID = Convert.ToInt32(lstOptions[i]), Description = "error" });
                    return result;
                }
            }

            return result;
        }

        public static string ResumeOrder(IEnumerable<OptionsSelected> distinctOptions)
        {
            var strReturn = "";

            distinctOptions = distinctOptions.GroupBy(x => x.Description).Select(y => y.First());

            //sort Dishes selected
            var sorted = from tuple in distinctOptions
                         orderby tuple.ID
                         select tuple;

            foreach (var opt in sorted)
            {
                if (opt.Description != "error")
                    strReturn += opt.Description + ",";
                else
                {
                    strReturn += opt.Description + ",";
                    break;
                }
            }

            return strReturn.TrimEnd(',');
        }

    }
}
