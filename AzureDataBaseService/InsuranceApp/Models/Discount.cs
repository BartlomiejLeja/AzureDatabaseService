using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class Discount
    {
        [ForeignKey("Client")]
        public int DiscountId { get; set; }
        public Client Client {get; set;}
        public double ValueOfDiscount { set; get; }
    }
}