using System;
//using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models.CarInsurances
{
    public class Payment
    {
      //  [ForeignKey("CarInsurance")]
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
        public CarInsurance CarInsurance { get; set; }
    }
}