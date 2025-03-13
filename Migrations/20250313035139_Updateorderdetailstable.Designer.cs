﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WareHouseProject;

#nullable disable

namespace WareHouseProject.Migrations
{
    [DbContext(typeof(WarehouseManagementContext))]
    [Migration("20250313035139_Updateorderdetailstable")]
    partial class Updateorderdetailstable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WareHouseProject.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WareHouseProject.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WareHouseProject.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("WareHouseProject.Models.SupplyOrder", b =>
                {
                    b.Property<int>("SupplyOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplyOrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("SupplyOrderId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("SupplyOrders");
                });

            modelBuilder.Entity("WareHouseProject.Models.SupplyOrderDetail", b =>
                {
                    b.Property<int>("SupplyOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplyOrderDetailId"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplyOrderId")
                        .HasColumnType("int");

                    b.HasKey("SupplyOrderDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SupplyOrderId");

                    b.ToTable("SupplyOrderDetails");
                });

            modelBuilder.Entity("WareHouseProject.Models.TransferOrder", b =>
                {
                    b.Property<int>("TransferOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransferOrderId"));

                    b.Property<int>("DestinationWarehouseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SourceWarehouseId")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("TransferOrderId");

                    b.HasIndex("DestinationWarehouseId");

                    b.HasIndex("SourceWarehouseId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("TransferOrders");
                });

            modelBuilder.Entity("WareHouseProject.Models.TransferOrderDetail", b =>
                {
                    b.Property<int>("TransferOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransferOrderDetailId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("TransferOrderId")
                        .HasColumnType("int");

                    b.HasKey("TransferOrderDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TransferOrderId");

                    b.ToTable("TransferOrderDetails");
                });

            modelBuilder.Entity("WareHouseProject.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("WareHouseProject.Models.WarehouseItem", b =>
                {
                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("WarehouseId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("WarehouseItems");
                });

            modelBuilder.Entity("WareHouseProject.Models.WithdrawalOrder", b =>
                {
                    b.Property<int>("WithdrawalOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WithdrawalOrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("WithdrawalOrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WithdrawalOrders");
                });

            modelBuilder.Entity("WareHouseProject.Models.WithdrawalOrderDetail", b =>
                {
                    b.Property<int>("WithdrawalOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WithdrawalOrderDetailId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("WithdrawalOrderId")
                        .HasColumnType("int");

                    b.HasKey("WithdrawalOrderDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("WithdrawalOrderId");

                    b.ToTable("WithdrawalOrderDetails");
                });

            modelBuilder.Entity("WareHouseProject.Models.SupplyOrder", b =>
                {
                    b.HasOne("WareHouseProject.Models.Supplier", "Supplier")
                        .WithMany("SupplyOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.Warehouse", "Warehouse")
                        .WithMany("SupplyOrders")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WareHouseProject.Models.SupplyOrderDetail", b =>
                {
                    b.HasOne("WareHouseProject.Models.Item", "Item")
                        .WithMany("SupplyOrderDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.SupplyOrder", "SupplyOrder")
                        .WithMany("SupplyOrderDetails")
                        .HasForeignKey("SupplyOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("SupplyOrder");
                });

            modelBuilder.Entity("WareHouseProject.Models.TransferOrder", b =>
                {
                    b.HasOne("WareHouseProject.Models.Warehouse", "DestinationWarehouse")
                        .WithMany()
                        .HasForeignKey("DestinationWarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.Warehouse", "SourceWarehouse")
                        .WithMany()
                        .HasForeignKey("SourceWarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.Warehouse", null)
                        .WithMany("TransferOrders")
                        .HasForeignKey("WarehouseId");

                    b.Navigation("DestinationWarehouse");

                    b.Navigation("SourceWarehouse");
                });

            modelBuilder.Entity("WareHouseProject.Models.TransferOrderDetail", b =>
                {
                    b.HasOne("WareHouseProject.Models.Item", "Item")
                        .WithMany("TransferOrderDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.Supplier", null)
                        .WithMany("TransferOrderDetails")
                        .HasForeignKey("SupplierId");

                    b.HasOne("WareHouseProject.Models.TransferOrder", "TransferOrder")
                        .WithMany("TransferOrderDetails")
                        .HasForeignKey("TransferOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("TransferOrder");
                });

            modelBuilder.Entity("WareHouseProject.Models.WarehouseItem", b =>
                {
                    b.HasOne("WareHouseProject.Models.Item", "Item")
                        .WithMany("WarehouseItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.Warehouse", "Warehouse")
                        .WithMany("WarehouseItems")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WareHouseProject.Models.WithdrawalOrder", b =>
                {
                    b.HasOne("WareHouseProject.Models.Customer", "Customer")
                        .WithMany("WithdrawalOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.Warehouse", "Warehouse")
                        .WithMany("WithdrawalOrders")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WareHouseProject.Models.WithdrawalOrderDetail", b =>
                {
                    b.HasOne("WareHouseProject.Models.Item", "Item")
                        .WithMany("WithdrawalOrderDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseProject.Models.WithdrawalOrder", "WithdrawalOrder")
                        .WithMany("WithdrawalOrderDetails")
                        .HasForeignKey("WithdrawalOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("WithdrawalOrder");
                });

            modelBuilder.Entity("WareHouseProject.Models.Customer", b =>
                {
                    b.Navigation("WithdrawalOrders");
                });

            modelBuilder.Entity("WareHouseProject.Models.Item", b =>
                {
                    b.Navigation("SupplyOrderDetails");

                    b.Navigation("TransferOrderDetails");

                    b.Navigation("WarehouseItems");

                    b.Navigation("WithdrawalOrderDetails");
                });

            modelBuilder.Entity("WareHouseProject.Models.Supplier", b =>
                {
                    b.Navigation("SupplyOrders");

                    b.Navigation("TransferOrderDetails");
                });

            modelBuilder.Entity("WareHouseProject.Models.SupplyOrder", b =>
                {
                    b.Navigation("SupplyOrderDetails");
                });

            modelBuilder.Entity("WareHouseProject.Models.TransferOrder", b =>
                {
                    b.Navigation("TransferOrderDetails");
                });

            modelBuilder.Entity("WareHouseProject.Models.Warehouse", b =>
                {
                    b.Navigation("SupplyOrders");

                    b.Navigation("TransferOrders");

                    b.Navigation("WarehouseItems");

                    b.Navigation("WithdrawalOrders");
                });

            modelBuilder.Entity("WareHouseProject.Models.WithdrawalOrder", b =>
                {
                    b.Navigation("WithdrawalOrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
