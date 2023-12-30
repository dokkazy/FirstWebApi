using FirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        #region Dbset
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                entity.Property(x => x.FullName).IsRequired();
                entity.Property(x => x.Address).IsRequired();
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(x => new { x.OrderId, x.ProductId });
                
                entity.HasOne(x => x.Order)
                      .WithMany(x => x.OrderDetails)
                      .HasForeignKey(x => x.OrderId)
                      .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(x => x.Product)
                      .WithMany(x => x.OrderDetails)
                      .HasForeignKey(x => x.ProductId)
                      .HasConstraintName("FK_OrderDetails_Products");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
