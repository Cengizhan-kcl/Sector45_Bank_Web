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
using Sector45_Bank.utils;

namespace Sector45_Bank.Controllers
{
    public class CreditController : Controller
    {
        // GET: Credit
        public ActionResult Index()
        {
            return View();
        }
        public string Check(string Credit,string Age, string CreditCount, string HomeState, string PhoneState)
        {
            Exp exp = new Exp() { credit =Convert.ToInt32(Credit), age = Convert.ToInt32(Age), creditCount = CreditCount!=""?Convert.ToInt32(CreditCount):0, home = HomeState=="true" ? 1:0, phoneState = PhoneState == "true" ? 1 : 0 };
            string body = JsonConvert.SerializeObject(exp);
            var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                Response<ExpResponse> response = Request<ExpResponse>.PostAsync("http://localhost:8080/credit", content);
                if (response.data!=null)
                {
                    if(response.data.CrediState== "Kredi Ver")
                    {
                        return JsonConvert.SerializeObject(new ReturnType() { status = true });
                    }
                    return JsonConvert.SerializeObject(new ReturnType() { status = false });
                }
                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
        }
    }
}