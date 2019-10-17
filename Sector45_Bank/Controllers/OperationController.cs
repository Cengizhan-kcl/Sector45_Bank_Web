using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sector45_Bank.Data;
using Sector45_Bank.Models;

namespace Sector45_Bank.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Index()
        {
            return View();
        }

        public void Deposit(string no,string amount)
        {
            Operation op = new Operation();
            Operations operation = new Operations();
            operation.amount = Convert.ToInt32(amount);
            operation.isDeposit = true;
            operation.accountNo = no;
            string body = JsonConvert.SerializeObject(operation);
            var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Response<Operation> response = Request<Operation>.PostAsync("http://localhost:3000/operation/deposit/", content);
        }

        public bool Withdraw(string no, string amount)
        {
            Operation op = new Operation();
            Operations operation = new Operations();
            operation.amount = Convert.ToInt32(amount);
            operation.isDeposit = false;
            operation.accountNo = no.ToString();
            string body = JsonConvert.SerializeObject(operation);
            var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Response<Operation> response = Request<Operation>.PostAsync("http://localhost:3000/operation/withdraw/", content);
            if(response.error!=null)
            { return false; }
            return true;
        }

    }
}