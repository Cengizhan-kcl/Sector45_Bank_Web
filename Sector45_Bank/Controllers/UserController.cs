using Newtonsoft.Json;
using Sector45_Bank.Models;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using JWT;
using JWT.Serializers;
using Sector45_Bank.Data;

namespace Sector45_Bank.Controllers
{
    public class UserController : Controller
    {
        // GET: Membership
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            string body = JsonConvert.SerializeObject(customer);
            var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            try
            {
                ViewBag.message = "";
                Response<Customer> task = Request<Customer>.PostAsync("http://localhost:3000/customer/login", content);
                if (task.error != null)
                {
                    ViewBag.message = task.error;
                    return View("Index");
                }
                Tkn.customer = task.data;
                Response<List<Account>> task2 = Request<List<Account>>.GetAsync("http://localhost:3000/customer/accounts/" + Tkn.customer.customerNo.ToString());
                Tkn.accounts = task2.data;
                return RedirectToAction("Index", "Membership");
            }
            catch (Exception e)
            {
                string[] subString = e.Message.Split('"');
                ViewBag.message = subString[1];
                return View("Index");
            }
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            string obj = JsonConvert.SerializeObject(customer);
            
            var url = "http://localhost:3000/customer/register";
            var content = new StringContent(obj.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                ViewBag.message = "";
                Response<Customer> response = Request<Customer>.PostAsync(url, content);
                if (response.error!=null)
                {
                    ViewBag.message = response.error;
                    return View("Register");
                }
                Response<List<Account>> task2 = Request<List<Account>>.GetAsync("http://localhost:3000/customer/accounts/" + Tkn.customer.customerNo.ToString());
                Tkn.accounts = task2.data;
                Tkn.customer = response.data;
                return RedirectToAction("Index", "Membership");
            }
            catch (Exception e)
            {
                string[] subString = e.Message.Split('"');
                ViewBag.message = subString[1];
                return View("Register");
            }
        }
    }
}