using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Eft
    {
        public double amount { get; set; }
        public string receiverAccountId { get; set; }
        public string senderAccountId { get; set; }
        public string source = "WEB";
    }
}