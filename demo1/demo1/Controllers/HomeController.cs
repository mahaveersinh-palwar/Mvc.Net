using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo1.Models;

namespace demo1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            List<Student> list = new List<Student>()
            {
                new Student()
                {
                    ID = 1,
                    Name = "MahaVeerSinh",
                    City = "Rajula"
                },

                  new Student()
                {
                    ID = 2,
                    Name = "Yash",
                    City = "Junagadh"
                },

                  new Student()
                {
                    ID = 3,
                    Name = "Dhaval",
                    City = "Dhasa"
                },

                  new Student()
                {
                    ID = 4,
                    Name = "Rahul",
                    City = "Jamngar"
                },

                     new Student()
                {
                    ID = 5,
                    Name = "Mukesh",
                    City = "Halvad"
                }
            };

            ViewBag.model = list;
            return View();
        }

        public ActionResult Aboutus()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(double number1, double number2, string operation)
        {
            double result = 0;

            switch (operation)
            {
                case "Addition":
                    result = number1 + number2;
                    ViewBag.Result = $"{number1} + {number2} = {result}";
                    break;
                case "Subtraction":
                    result = number1 - number2;
                    ViewBag.Result = $"{number1} - {number2} = {result}";
                    break;
                case "Multipication":
                    result = number1 * number2;
                    ViewBag.Result = $"{number1} * {number2} = {result}";
                    break;
                case "Division":
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                        ViewBag.Result = $"{number1} / {number2} = {result}";
                    }
                    else
                    {
                        ViewBag.Result = "Cannot divide by zero";
                    }
                    break;
                default:
                    ViewBag.Result = "Invalid operation";
                    break;
            }

            return View("Contact");
        }
    }
}

