using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantOrder;
using RestaurantClasses;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RestaurantOrderTest
{
    [TestClass]
    public class RestaurantMenuTest
    {
        [TestMethod]
        public void ProcessOrder_Test_1()
        {
            string options = "morning,1,2,3";
            string result = "";
            string Exp_result = "Eggs,Toast,Coffee";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }

        [TestMethod]
        public void ProcessOrder_Test_2()
        {
            string options = "morning, 2, 1, 3";
            string result = "";
            string Exp_result = "Eggs,Toast,Coffee";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }

        [TestMethod]
        public void ProcessOrder_Test_3()
        {
            string options = "morning, 1, 2, 3, 4";
            string result = "";
            string Exp_result = "Eggs,Toast,Coffee,error";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }

        [TestMethod]
        public void ProcessOrder_Test_4()
        {
            string options = "morning, 1, 2, 3, 3, 3";
            string result = "";
            string Exp_result = "Eggs,Toast,Coffee(x3)";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }

        [TestMethod]
        public void ProcessOrder_Test_5()
        {
            string options = "night, 1, 2, 3, 4";
            string result = "";
            string Exp_result = "Steak,Potato,Wine,Cake";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }

        [TestMethod]
        public void ProcessOrder_Test_6()
        {
            string options = "night, 1, 2, 2, 4";
            string result = "";
            string Exp_result = "Steak,Potato(x2),Cake";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }

        [TestMethod]
        public void ProcessOrder_Test_7()
        {
            string options = "night, 1, 2, 3, 5";
            string result = "";
            string Exp_result = "Steak,Potato,Wine,error";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }

        [TestMethod]
        public void ProcessOrder_Test_8()
        {
            string options = "night, 1, 1, 2, 3, 5 ";
            string result = "";
            string Exp_result = "Steak,error";
            List<Period> lstPeriod = new List<Period>();
            List<Dish> lstDish = new List<Dish>();

            lstPeriod = Period.setPeriods();
            lstDish = Dish.setDish();

            IEnumerable<RestaurantMenu.OptionsSelected> distinctOptions = RestaurantMenu.ProcessOrder(Regex.Replace(options, @"\s", "").ToUpper(), lstPeriod, lstDish);
            result = RestaurantMenu.ResumeOrder(distinctOptions);

            Assert.AreEqual(Exp_result, result);
        }
    }
}
