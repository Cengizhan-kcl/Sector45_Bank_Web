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
using Sector45_Bank.utils;

namespace Sector45_Bank.Controllers
{
    public class OperationController : Controller
    {
        public string Deposit(string no,string amount)
        {
            try
            {
                Operations operation = new Operations();
                operation.amount = Convert.ToDouble(amount);
                operation.isDeposit = true;
                operation.accountNo = no;
                string body = JsonConvert.SerializeObject(operation);
                var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response<Operation> response = Request<Operation>.PostAsync("http://localhost:3000/operation/deposit/", content);
                if (response.error != null)
                { return JsonConvert.SerializeObject(new ReturnType() { status = false }); }
                return JsonConvert.SerializeObject(new ReturnType() { status = true });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
        }

        public string Withdraw(string no, string amount)
        {
            try
            {
                Operations operation = new Operations();
                operation.amount = Convert.ToDouble(amount);
                operation.isDeposit = false;
                operation.accountNo = no.ToString();
                string body = JsonConvert.SerializeObject(operation);
                var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response<Operation> response = Request<Operation>.PostAsync("http://localhost:3000/operation/withdraw/", content);
                if (response.error != null)
                { return JsonConvert.SerializeObject(new ReturnType() { status = false }); }
                return JsonConvert.SerializeObject(new ReturnType() { status = true });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
        }
        public string transfer(string no1, string no2,string amount)
        {
            try
            {
                Eft eft = new Eft() { amount = Convert.ToDouble(amount), senderAccountId = no1, receiverAccountId = no2 };
                string body = JsonConvert.SerializeObject(eft);
                var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response<Operation> response = Request<Operation>.PostAsync("http://localhost:3000/transaction/", content);
                if (response.error != null)
                {
                    return JsonConvert.SerializeObject(new ReturnType() { status = false });
                }
                return JsonConvert.SerializeObject(new ReturnType() { status = true });
            } 
            catch (Exception e)
            {

                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
        }
    }
}