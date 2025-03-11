using Microsoft.EntityFrameworkCore;
using WareHouseProject.Models;

namespace WareHouseProject
{
    public class WarehouseManagementContext : DbContext
    {
        public WarehouseManagementContext(DbContextOptions<WarehouseManagementContext> options) : base(options) { }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<SupplyOrder> SupplyOrders { get; set; }
        public DbSet<SupplyOrderDetail> SupplyOrderDetails { get; set; }
        public DbSet<WithdrawalOrder> WithdrawalOrders { get; set; }
        public DbSet<WithdrawalOrderDetail> WithdrawalOrderDetails { get; set; }
        public DbSet<TransferOrder> TransferOrders { get; set; }
        public DbSet<TransferOrderDetail> TransferOrderDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KHALED\SQLEXPRESS;Database=WarehouseManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<WarehouseItem>()
                .HasKey(wi => new { wi.WarehouseId, wi.ItemId });

        
            modelBuilder.Entity<TransferOrder>()
                .HasOne(to => to.SourceWarehouse)
                .WithMany()
                .HasForeignKey(to => to.SourceWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferOrder>()
                .HasOne(to => to.DestinationWarehouse)
                .WithMany()
                .HasForeignKey(to => to.DestinationWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
