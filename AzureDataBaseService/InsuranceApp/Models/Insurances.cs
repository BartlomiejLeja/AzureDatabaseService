//using InsuranceRestSerwer.Models.CarInsurances;
using InsuranceApp.Models.CarInsurances;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;


namespace InsuranceApp.Models
{
    public class Insurances
    {
        //   [ForeignKey("Client")]
        public int InsurancesId { get; set; }
        public Client Client { get; set; }
        public List<CarInsurance> CarInsurance { get; set; }
        public List<RealEstateInsurance> RealEstateInsurance { get; set; }
        public List<TravelInsurance> TravelInsurance { get; set; }


        public Insurances()
        {
            RealEstateInsurance = new List<Models.RealEstateInsurance>();
        }
    }

    
}