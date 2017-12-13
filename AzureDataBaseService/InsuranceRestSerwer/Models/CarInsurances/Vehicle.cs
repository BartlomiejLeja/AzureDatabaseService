using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceRestSerwer.Models.CarInsurances
{
    public class Vehicle
    {
        [ForeignKey("CarInsurance")]
        public int VehicleId { get; set; }
        public double  EngineCapacity { get; set; }
        public DateTime ProductionYear { get; set; }
        public double Value { get; set; }
        public CarInsurance CarInsurance { get; set; }
    }
}