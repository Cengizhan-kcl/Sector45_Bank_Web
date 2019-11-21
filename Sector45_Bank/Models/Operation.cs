using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Operation:Body
    {
        public int operationId { get; set; }
        public double amount { get; set; }
        public bool isDeposit { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public Account account { get; set; }
    }
}