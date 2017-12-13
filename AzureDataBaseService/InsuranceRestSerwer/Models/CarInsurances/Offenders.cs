using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceRestSerwer.Models.CarInsurances
{
    public class Offenders
    {
        [ForeignKey("CarInsuranceApplication")]
        public int OffendersId { get; set; }
        public int PeselNumber { get; set; }
        public string Adress { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public CarInsuranceApplication CarInsuranceApplication { get; set; }
    }
}