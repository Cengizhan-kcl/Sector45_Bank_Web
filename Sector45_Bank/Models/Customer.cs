using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Models
{
    public class Customer
    {
        public int customerNo{ get; set; }
        public string TCKN{ get; set; }
        public string password{ get; set; }
        public int salary{ get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Address address{ get; set; }
        public DateTime dateOfBirth{ get; set; }
    }
}