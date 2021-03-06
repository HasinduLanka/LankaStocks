﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    [Serializable]

    public class Person
    {
        public uint ID;
        public string name;
        public string details;
        public string contactInfo;

        public Transaction summary = new Transaction() { ID = 1, type = Transaction.Types.Summary };
    }

    [Serializable]

    public class User : Person
    {

        public string userName;
        public string pass;
        public bool isAdmin;


    }

    [Serializable]

    public class Vendor : Person
    {
        public uint VendorID;
        public string BusinessInfo;

        public List<uint> supplyingItems = new List<uint>();//<ItemID>
    }
}
