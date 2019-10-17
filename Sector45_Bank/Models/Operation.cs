using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Operation
    {
        public int operationId { get; set; }
        public int amount { get; set; }
        public bool isDeposit { get; set; }
        public DateTime date { get; set; }
        public Account account { get; set; }
    }
}