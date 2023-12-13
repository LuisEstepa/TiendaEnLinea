using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int? PaymentID { get; set; }
        public int? ShippingID { get; set; }
        public int? Discount { get; set; }
        public int? Taxes { get; set; }
        public int? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? DIspatched { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public bool? Shipped { get; set; }
        public DateTime? ShippingDate { get; set; }
        public bool? Deliver { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Notes { get; set; }
        public bool? CancelOrder { get; set; }


        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("PaymentID")]
        public virtual Payment Payment { get; set; }

        [ForeignKey("ShippingID")]
        public virtual ShippingDetail ShippingDetail { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
