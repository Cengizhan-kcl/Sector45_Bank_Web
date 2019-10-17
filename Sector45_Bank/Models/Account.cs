using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Account
    {
        public string accountNo { get; set; }
        public int balance { get; set; }
        public bool isActive { get; set; }
        public Customer customer { get; set; }
        public List<Transaction> transactions { get; set; }
        public List<Operation> operations { get; set; }
    }
}