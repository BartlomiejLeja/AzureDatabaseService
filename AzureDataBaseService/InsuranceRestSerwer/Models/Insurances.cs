using InsuranceRestSerwer.Models.CarInsurances;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace InsuranceRestSerwer.Models
{
    public class Insurances
    {
        public Insurances()
        {
            this.RealEstateInsurance = new HashSet<RealEstateInsurance>();
        }
        [ForeignKey("Client")]
        public int InsurancesId { get; set; }
        public Client Client { get; set; }
        public List<CarInsurance> CarInsurance { get; set; }
        public ICollection<RealEstateInsurance> RealEstateInsurance { get; set; }
        public List<TravelInsurance> TravelInsurance { get; set; }
    }
}