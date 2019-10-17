using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Address
    {
        public int id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string district { get; set; }
        public int no { get; set; }
        public Customer customer { get; set; }
    }
}