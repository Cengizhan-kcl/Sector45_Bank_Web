using Newtonsoft.Json;
using Sector45_Bank.Data;
using Sector45_Bank.Models;
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

        public void add()
        {
            Response<Account> response = Request<Account>.GetAsync("http://localhost:3000/account/new/"+Tkn.customer.customerNo.ToString());
            Tkn.accounts.Add(response.data);
        }
         public bool remove(string no)
        {
            try
            {
                Response<Account> res = Request<Account>.GetAsync("http://localhost:3000/account/close/" + no);
                if (res.error != null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost]
        public void transaction(string no)
        {
            Response<List<Operation>> operations = Request< List <Operation>>.GetAsync("http://localhost:3000/operation/" + no);
            Response<List<Transaction>> transactions = Request<List<Transaction>>.GetAsync("http://localhost:3000/transaction/" + no);
            Tkn.operations = null;
            Tkn.transactions = null;
            Tkn.transactions = transactions.data;
            Tkn.operations = operations.data;
        }
        public void account()
        {
            Response<List<Account>> task2 = Request<List<Account>>.GetAsync("http://localhost:3000/account/" + Tkn.customer.customerNo.ToString());
            Tkn.accounts = null;
            Tkn.accounts = task2.data;
        }
    }
}