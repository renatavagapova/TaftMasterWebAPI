using Microsoft.EntityFrameworkCore;
using TaftMasterWebAPI.Models;

namespace TaftMasterWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Rug> Rugs { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FavoriteItem> FavoriteItems { get; set; }
        public DbSet<MasterClass> MasterClasses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<RugRequest> RugRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Rug)
                .WithMany()  // Указываем, что Rug может быть в нескольких записях CartItem
                .HasForeignKey(ci => ci.RugId)
                .OnDelete(DeleteBehavior.Cascade);  // Если Rug удаляется, удаляем CartItems

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Certificate)
                .WithMany()  // Указываем, что Certificate может быть в нескольких записях CartItem
                .HasForeignKey(ci => ci.CertificateId)
                .OnDelete(DeleteBehavior.Cascade);  // Если Certificate удаляется, удаляем CartItems

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
