using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceRestSerwer.Models
{
    public class Insurances
    {
        [ForeignKey("Client")]
        public int InsurancesId { get; set; }
        public Client Client { get; set; }
        public List<HealthInsurance> HealthInsurances { get; set; }
    }
}