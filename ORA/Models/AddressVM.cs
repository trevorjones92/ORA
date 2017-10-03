﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class AddressVM
    {
        public int Address_ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip_Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}