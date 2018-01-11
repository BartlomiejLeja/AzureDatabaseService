//using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class ClientData
    {
      // [ForeignKey("Client")]
        public int ClientDataId { get; set; }
        public virtual Client Client { get; set; }
        public int PeselNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Adress { get; set; }
        public int CarUsingPeriod { get; set; }
    }
}