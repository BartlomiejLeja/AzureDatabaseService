using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace InsuranceRestSerwer.Models
{
    public class ClientData
    {
        [ForeignKey("Client")]
        public int ClientDataId { get; set; }
        public int PeselNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public int CarUsingPeriod { get; set; }
        public virtual Client Client { get; set; }
    }
}