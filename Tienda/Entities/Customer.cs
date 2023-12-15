using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string Organization { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Picture { get; set; }
        public string status { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? Created { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> Wishlists { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
