using Newtonsoft.Json;
using Sector45_Bank.Data;
using Sector45_Bank.Models;
using Sector45_Bank.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sector45_Bank.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Operations()
        {
            return View();
        }
        public ActionResult Transfer()
        {
            return View();
        }

        public string add()
        {
            try
            {
                Response<Account> response = Request<Account>.GetAsync("http://localhost:3000/account/new/" + Tkn.customer.customerNo.ToString());
                Tkn.accounts.Add(response.data);
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

         public string remove(string no)
        {
            try
            {
                Response<Account> res = Request<Account>.GetAsync("http://localhost:3000/account/close/" + no);
                if (res.error != null)
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

        [HttpPost]
        public string transaction(string no)
        {
            try
            {
                Response<List<Operation>> operations = Request<List<Operation>>.GetAsync("http://localhost:3000/operation/" + no);
                Response<List<Transaction>> transactions = Request<List<Transaction>>.GetAsync("http://localhost:3000/transaction/" + no);
                Tkn.operations = null;
                Tkn.transactions = null;
                Tkn.transactions = transactions.data;
                Tkn.operations = operations.data;
                if (operations.error != null || transactions.error!=null)
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
        public string account()
        {
            try
            {
                Response<List<Account>> task2 = Request<List<Account>>.GetAsync("http://localhost:3000/account/" + Tkn.customer.customerNo.ToString());
                Tkn.accounts = null;
                Tkn.accounts = task2.data;
                if (task2.error != null)
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