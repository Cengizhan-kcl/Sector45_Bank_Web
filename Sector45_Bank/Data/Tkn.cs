﻿using Sector45_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sector45_Bank.Data
{
    public static class Tkn
    {
       public static Customer customer;
        public static List<Account> accounts;
        public static List<Operation> operations;
        public static List<Operation> hgsOperations;
        public static List<Transaction> transactions;
        public static List<Card> hgsCards { get; set; }
    }
}