using CookieSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var prod1 = new Product()
            {
                ProductID = 100,
                Price = 9.99,
                Quantity = 2
            };

            var prod2 = new Product()
            {
                ProductID = 130,
                Price = 20,
                Quantity = 1
            };

            List<Product> products = new List<Product>() { prod1, prod2 };
            // create a cookie
            var cookie = new HttpCookie("Test");
            // cookie.Value = "Rob Was here";
            // convert all products to a json string
            cookie.Value = JsonConvert.SerializeObject(products);
            cookie.Expires = DateTime.Now.AddDays(7);
            // sends the cookie to the user
            Response.Cookies.Add(cookie);

            return View();
        }

        public ActionResult About()
        {
            // read cookie data
            if(Request.Cookies["Test"] != null)
            {
                string data = Request.Cookies["Test"].Value;
                List<Product> prods = JsonConvert.DeserializeObject<List<Product>>(data);
                return View(prods);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}