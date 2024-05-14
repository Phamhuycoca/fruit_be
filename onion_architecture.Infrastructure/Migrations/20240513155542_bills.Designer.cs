﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using onion_architecture.Infrastructure.Context;

#nullable disable

namespace onion_architecture.Infrastructure.Migrations
{
    [DbContext(typeof(onion_architecture_Context))]
    [Migration("20240513155542_bills")]
    partial class bills
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("onion_architecture.Domain.Entity.Bill", b =>
                {
                    b.Property<long>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BillId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Bill_Status")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Payments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Total_amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("createdBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("deletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("updatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("BillId");

                    b.HasIndex("UserId");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Cart", b =>
                {
                    b.Property<long>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CartId"), 1L, 1);

                    b.Property<long>("FruitId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("createdBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("deletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("updatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("CartId");

                    b.HasIndex("FruitId");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Category", b =>
                {
                    b.Property<long>("CategoriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CategoriesId"), 1L, 1);

                    b.Property<string>("CategoriesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("createdBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("deletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("updatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("CategoriesId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Fruit", b =>
                {
                    b.Property<long>("FruitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FruitId"), 1L, 1);

                    b.Property<long>("CategoriesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FruitDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FruitImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FruitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FruitPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FruitQuantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PriceDiscount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("createdBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("deletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("updatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("FruitId");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("StoreId");

                    b.ToTable("Fruits", (string)null);
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Refresh_Token", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RefreshTokenExpiration")
                        .HasColumnType("int");

                    b.Property<DateTime>("Refresh_TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("createdBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("deletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("updatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Store", b =>
                {
                    b.Property<long>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StoreId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("createdBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("deletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("updatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("StoreId");

                    b.ToTable("Stores", (string)null);
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool?>("Is_Active")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("createdBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("deletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("updatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Bill", b =>
                {
                    b.HasOne("onion_architecture.Domain.Entity.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Cart", b =>
                {
                    b.HasOne("onion_architecture.Domain.Entity.Fruit", "Fruit")
                        .WithMany("Carts")
                        .HasForeignKey("FruitId")
                        .IsRequired();

                    b.HasOne("onion_architecture.Domain.Entity.Store", "Store")
                        .WithMany("Carts")
                        .HasForeignKey("StoreId")
                        .IsRequired();

                    b.HasOne("onion_architecture.Domain.Entity.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Fruit");

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Fruit", b =>
                {
                    b.HasOne("onion_architecture.Domain.Entity.Category", "Category")
                        .WithMany("Fruits")
                        .HasForeignKey("CategoriesId")
                        .IsRequired();

                    b.HasOne("onion_architecture.Domain.Entity.Store", "Store")
                        .WithMany("Fruits")
                        .HasForeignKey("StoreId")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Refresh_Token", b =>
                {
                    b.HasOne("onion_architecture.Domain.Entity.User", "User")
                        .WithMany("Refresh_Tokens")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Category", b =>
                {
                    b.Navigation("Fruits");
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Fruit", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.Store", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Fruits");
                });

            modelBuilder.Entity("onion_architecture.Domain.Entity.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Carts");

                    b.Navigation("Refresh_Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
