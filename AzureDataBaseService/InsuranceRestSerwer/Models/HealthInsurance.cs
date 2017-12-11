using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceRestSerwer.Models
{
    public class HealthInsurance
    {
        public int HealthInsuranceId { get; set; }

        public int Insurance { get; set; }
        public Insurances Insurances { get; set; }
    }
}