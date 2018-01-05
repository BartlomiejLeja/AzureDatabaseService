using InsuranceRestSerwer.Models.TravelInsurances;
using System;
using System.Collections.Generic;

namespace InsuranceRestSerwer.Models
{
    public class TravelInsurance
    {
        public int TravelInsuranceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfInsuredPersons { get; set; }
        public int NumberOfInsuredPersonsOverAge26 { get; set; }
        public int NumberOfInsuredPersonsOverAge65 { get; set; }
        public int NumberOfInsuredPersonsBetween26and65 { get; set; }
        public double InsuranceCost { get; set; }
        public List<AdditionalOptions> AdditionalOptionList { get; set; }
        public List<Region> RegionList { get; set; }
        public int Insurance { get; set; }
        public Insurances Insurances { get; set; }
    }
}