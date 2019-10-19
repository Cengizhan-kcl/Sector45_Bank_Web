using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sector45_Bank.Data;

namespace Sector45_Bank.Controllers
{
    public class MembershipController : Controller
    {
        // GET: Membership
        public ActionResult Index()
        {
            return View();
        }
        
        public void LogOut()
        {
            Tkn.customer = null;
            Tkn.accounts = null;
            Tkn.operations = null;
            Tkn.transactions = null;
            ViewBag.message = null;
        }
    }
}