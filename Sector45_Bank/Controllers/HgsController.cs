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
    public class HgsController : Controller
    {
        // GET: Hgs
        public ActionResult Index()
        {
            return View();
        }

        public string cards()
        {
            try
            {
                Response<List<Card>> res = Request<List<Card>>.GetAsync("http://localhost:5000/card/"+Tkn.customer.TCKN.ToString());
                if (res.error != null)
                {
                    return JsonConvert.SerializeObject(new ReturnType() { status = false });
                }
                else
                {
                    Tkn.hgsCards = res.data;
                    return JsonConvert.SerializeObject(new ReturnType() { status = true });
                }
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
        }
        public string add(string no,string amount)
        {
            try
            {
                Operations operations = new Operations();
                operations.accountNo = no;
                operations.amount = Convert.ToDouble(amount);
                string body = JsonConvert.SerializeObject(operations);
                var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response<List<Card>> res = Request<List<Card>>.PostAsync("http://localhost:3000/hgs/register/",content);
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
        public string operation(string no)
        {
            try
            {
                Response<List<Operation>> res = Request<List<Operation>>.GetAsync("http://localhost:5000/operation/"+no);
                if (res.error != null)
                {
                    return JsonConvert.SerializeObject(new ReturnType() { status = false });
                }
                Tkn.hgsOperations = res.data;
                return JsonConvert.SerializeObject(new ReturnType() { status = true });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
        }
        public string deposit(string amount,string accountNo,string cardNo)
        {
            try
            {
                OperationHgs op = new OperationHgs();
                op.amount = Convert.ToDouble(amount);
                op.accountNo = accountNo;
                op.cardId = Convert.ToInt32(cardNo);
                string body = JsonConvert.SerializeObject(op);
                var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response<Operation> res = Request<Operation>.PostAsync("http://localhost:3000/hgs/deposit",content);
                if (res.error != null)
                { return JsonConvert.SerializeObject(new ReturnType() { status = false }); }
                return JsonConvert.SerializeObject(new ReturnType() { status = true });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new ReturnType() { status = false });
            }
        }
    }
}