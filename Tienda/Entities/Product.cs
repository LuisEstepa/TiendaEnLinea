using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public string UnitWeight { get; set; }
        public string Size { get; set; }
        public decimal? Discount { get; set; }
        public int? UnitInStock { get; set; }
        public int? UnitOnOrder { get; set; }
        public bool? ProductAvailable { get; set; }
        public string ImageURL { get; set; }
        public string AltText { get; set; }
        public bool? AddBadge { get; set; }
        public string OfferTitle { get; set; }
        public string OfferBadgeClass { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string Picture4 { get; set; }
        public string Note { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        
        [ForeignKey("SubCategoryID")]
        public virtual SubCategory SubCategory { get; set; }
        
        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> Wishlists { get; set; }
    }
}
