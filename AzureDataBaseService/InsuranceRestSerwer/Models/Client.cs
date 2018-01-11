﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceRestSerwer.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public virtual ClientData ClientData { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Insurances Insurances { get; set; }
    }
}