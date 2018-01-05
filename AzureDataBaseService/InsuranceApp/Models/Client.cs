using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        // [MaxLength(30)]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public virtual ClientData ClientData { get; set; }
        public Discount Discount { get; set; }
        public Insurances Insurances { get; set; }


        public Client()
        {
            Insurances = new Insurances();
        }
    }

}