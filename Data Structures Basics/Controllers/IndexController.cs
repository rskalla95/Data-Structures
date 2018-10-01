using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures_Basics.Controllers
{
    public class IndexController : Controller
    {
        //Implement Random Function
        public static Random random = new Random();

        //Implement Random Name Function
        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        //Implement Random Number Function
        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

        // GET: Index
        public ActionResult Index()
        { 
            Queue<string> line = new Queue<string>(); //Initialize Queue
            Dictionary<string, int> customers = new Dictionary<string, int>(); //Initialize Dictionary

            //Add 100 customers to thr Queue
            for (int i = 0; i < 100; i++)
            {
                line.Enqueue(randomName());
            }

            //Iterate through the queue
            while (line.Count > 0)
            {
                //If the dictionary already includes the customer, Dequeue and increment by random number
                if (customers.ContainsKey(line.Peek()))
                {
                    customers[line.Dequeue()] += randomNumberInRange();
                }

                //If the dictionary doesn't include the customer, dequeue and add customer to the dictionary with a random number of burgers
                else
                {
                    customers.Add(line.Dequeue(), randomNumberInRange());
                }
            }

            //Create table
            ViewBag.Output += "<table class=\"table table-striped table-hover\" style=\"background-color: #fff\">";
            ViewBag.Output += "<thead class=\"thead-dark\">";
            ViewBag.Output += "<tr>";
            ViewBag.Output += "<th>Customer Name</th>";
            ViewBag.Output += "<th>Burgers Consumed</th>";
            ViewBag.Output += "</tr>";
            ViewBag.Output += "</thead>";
            ViewBag.Output += "<tbody id=\"myTable\">";


            //Output each customer from the dictionary into the table
            foreach (KeyValuePair<string, int> entry in customers)
            {
                ViewBag.Output += "<tr>";
                ViewBag.Output += "<td>" + entry.Key + "</td>";
                ViewBag.Output += "<td>" + entry.Value + "</td>";
                ViewBag.Output += "</tr>";
            }

            return View();
        }
    }
}