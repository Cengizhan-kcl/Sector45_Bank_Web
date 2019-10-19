using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sector45_Bank.Models;

namespace Sector45_Bank.Controllers
{
    public class CreditController : Controller
    {
        // GET: Credit
        public ActionResult Index()
        {
            return View();
        }
        public string Check(string experience)
        {
            Exp exp = new Exp() { exp =Convert.ToDouble(experience) };
            string body = JsonConvert.SerializeObject(exp);
            var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                Response<ExpResponse> response = Request<ExpResponse>.PostAsync("http://localhost:8080/credit", content);
                if (response.data!=null)
                {
                    return response.data.Salary;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}