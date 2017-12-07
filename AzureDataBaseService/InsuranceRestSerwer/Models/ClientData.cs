using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceRestSerwer.Models
{
    public class ClientData
    {
        [ForeignKey("Client")]
        public int ClientDataId { get; set; }

        public virtual Client Client { get; set; }
        public int PeselNumber { get; set; }
    }
}