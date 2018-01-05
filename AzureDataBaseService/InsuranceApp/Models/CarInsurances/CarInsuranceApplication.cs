using System;

namespace InsuranceApp.Models.CarInsurances
{
    public class CarInsuranceApplication
    {
        public int CarInsuranceApplicationId{get;set;}
        public string Statsu { get; set; }
        public DateTime Date { get; set; }
        public string AccidentPlace { get; set; }
        public CarInsurance CarInsurance { get; set; }
        public Offenders Offenders { get; set; }
    }
}