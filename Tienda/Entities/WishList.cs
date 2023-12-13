using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [PrimaryKey(nameof(WishlistID), nameof(CustomerID), nameof(ProductID))]
    public class WishList
    {
        public int WishlistID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
