using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures_Basics.Controllers
{
    public class IndexController : Controller
    {

        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

        // GET: Index
        public ActionResult Index()
        { 
            Queue<string> line = new Queue<string>();
            Dictionary<string, int> customers = new Dictionary<string, int>();

            for (int i = 0; i < 100; i++)
            {
                line.Enqueue(randomName());
            }

            while (line.Count > 0)
            {
                if (customers.ContainsKey(line.Peek()))
                {
                    customers[line.Dequeue()] += randomNumberInRange();
                }

                else
                {
                    customers.Add(line.Dequeue(), 0);
                }
            }

            ViewBag.Output += "<table class=\"table table-striped table-hover\" style=\"background-color: #fff\">";
            ViewBag.Output += "<thead class=\"thead-dark\">";
            ViewBag.Output += "<tr>";
            ViewBag.Output += "<th>Customer Name</th>";
            ViewBag.Output += "<th>Burgers Consumed</th>";
            ViewBag.Output += "</tr>";
            ViewBag.Output += "</thead>";
            ViewBag.Output += "<tbody id=\"myTable\">";

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