using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TiendaContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<GenMainSlider> genMainSliders { get; set; }
        public DbSet<GenPromoRight> genPromoRights { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SysDiagram> sysdiagrams { get; set; }
        public DbSet<WishList> Wishlists { get; set; }
        public DbSet<AdminEmployee> AdminEmployee { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
        public DbSet<Order> Orders { get; set; }

        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}
