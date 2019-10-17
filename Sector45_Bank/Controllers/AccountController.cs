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
        public void add()
        {
            Response<Account> response = Request<Account>.GetAsync("http://localhost:3000/account/new/"+Tkn.customer.customerNo.ToString());
            Tkn.accounts.Add(response.data);
        }
         public void remove(string no)
        {
            Request<Account>.GetAsync("http://localhost:3000/account/close/"+no);
        }
        [HttpPost]
        public void transaction(string no)
        {
            Response<List<Operation>> operations = Request< List <Operation>>.GetAsync("http://localhost:3000/account/operations/" + no);
            Tkn.operations = null;
            Tkn.operations = operations.data;
        }
        public void account()
        {
            Response<List<Account>> task2 = Request<List<Account>>.GetAsync("http://localhost:3000/customer/accounts/" + Tkn.customer.customerNo.ToString());
            Tkn.accounts = null;
            Tkn.accounts = task2.data;
        }
    }
}