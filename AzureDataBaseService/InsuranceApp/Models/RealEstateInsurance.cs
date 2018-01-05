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


        public RealEstateInsurance()
        {
            MetricArea = 50;
            NumberOfFloors = 2;
            NumberOfGarages = 1;
            ConstructionDate = DateTime.Now;
            HasBasement = true;
            Adress = "Wolska 25";
            PropertyType = "Dom jednorodzinny";
            StartDate = DateTime.Now;
            FinishDate = DateTime.Now;

        }

        public override string ToString()
        {


            return "Metryka: " + MetricArea +
                "\nIlość pięter: " + NumberOfFloors +
                "\nIlość garaży: " + NumberOfGarages +
                "\nMa piwnicę? " + HasBasement +
                "\nAdres: " + Adress +
                "\nPoczątek ubezpieczenia: " + StartDate +
                "\nKoniec ubezpieczenia: " + FinishDate + "\n";
                
        }
    }
}