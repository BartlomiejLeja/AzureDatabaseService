using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceRestSerwer.Models.CarInsurances
{
    public class TypeOfCarInsurance
    {
        [ForeignKey("CarInsurance")]
        public int TypeOfCarInsuranceId { get; set; }
        public string Type { get; set; }
        public CarInsurance CarInsurance { get; set; }
    }
}