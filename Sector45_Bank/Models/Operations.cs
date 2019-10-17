using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Operations
    {
        public int amount{ get; set; }
        public bool isDeposit{ get; set; }
        public string accountNo{ get; set; }
    }
}