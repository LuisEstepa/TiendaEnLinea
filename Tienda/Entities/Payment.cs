using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int Type { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? PaymentDateTime { get; set; }

        [ForeignKey("Type")]
        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
