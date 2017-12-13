using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models.TravelInsurances
{
    public class AdditionalOptions
    {
        public int AdditionalOptionsId { get; set; }
        public string Name { get; set; }
        public TravelInsurance TravelInsurance { get; set; }
     }
}