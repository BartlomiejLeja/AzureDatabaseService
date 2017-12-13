using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class RealEstateInsurance
    {
        public int RealEstateInsuranceId { get; set; }
        public double MetricArea { get; set; }
        public int NumberOfFloors { get; set; }
        public DateTime ConstructionDate { get; set; }
        public int NumberOfGarages { get; set; }
        public bool HasBasement { get; set; }
        public string Adress { get; set; }
        public string PropertyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Insurance { get; set; }
        public Insurances Insurances { get; set; }
    }
}