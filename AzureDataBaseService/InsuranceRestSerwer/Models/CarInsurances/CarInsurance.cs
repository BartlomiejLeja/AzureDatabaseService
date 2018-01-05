using System;
using System.Collections.Generic;

namespace InsuranceRestSerwer.Models.CarInsurances
{
    public class CarInsurance
    {
        public int CarInsuranceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public TypeOfCarInsurance Type { get; set; }
        public Payment Payment { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<CarInsuranceApplication> ApplicationList { get; set; }
        public int Insurance { get; set; }
        public Insurances Insurances { get; set; }
    }
}