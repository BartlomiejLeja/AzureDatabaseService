//using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models.CarInsurances
{
    public class TypeOfCarInsurance
    {
      //  [ForeignKey("CarInsurance")]
        public int TypeOfCarInsuranceId { get; set; }
        public string Type { get; set; }
        public CarInsurance CarInsurance { get; set; }
    }
}