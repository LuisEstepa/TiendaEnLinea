using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int? CustomerID { get; set; }
        public int? ProductID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Review1 { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<bool> isDelete { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
