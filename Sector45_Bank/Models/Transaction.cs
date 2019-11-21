using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Transaction:Body
    {
        public int transactionNo { get; set; }
        public double amount { get; set; }
        public Account senderAccount { get; set; }
        public Account receiverAccount { get; set; }
        public DateTime date { get; set; }
        public bool isLocal { get; set; }
    }
}