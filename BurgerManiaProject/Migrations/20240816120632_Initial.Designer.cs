﻿// <auto-generated />
using BurgerManiaProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerManiaProject.Migrations
{
    [DbContext(typeof(BurgerMgmtDbContext))]
    [Migration("20240816120632_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BurgerManiaProject.Models.Burger", b =>
                {
                    b.Property<int>("BurgerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurgerId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BurgerId");

                    b.ToTable("Burgers");

                    b.HasData(
                        new
                        {
                            BurgerId = 1,
                            Name = "Cheesy Delicious",
                            Price = 100m,
                            Type = "Veg"
                        },
                        new
                        {
                            BurgerId = 2,
                            Name = "Cheesy Delicious",
                            Price = 200m,
                            Type = "Non-Veg"
                        },
                        new
                        {
                            BurgerId = 3,
                            Name = "Cheesy Delicious",
                            Price = 150m,
                            Type = "Egg"
                        },
                        new
                        {
                            BurgerId = 4,
                            Name = "Cheesy Surprise",
                            Price = 100m,
                            Type = "Veg"
                        },
                        new
                        {
                            BurgerId = 5,
                            Name = "Cheesy Surprise",
                            Price = 200m,
                            Type = "Non-Veg"
                        },
                        new
                        {
                            BurgerId = 6,
                            Name = "Cheesy Surprise",
                            Price = 150m,
                            Type = "Egg"
                        },
                        new
                        {
                            BurgerId = 7,
                            Name = "Cheesy Chilli",
                            Price = 100m,
                            Type = "Veg"
                        },
                        new
                        {
                            BurgerId = 8,
                            Name = "Cheesy Chilli",
                            Price = 200m,
                            Type = "Non-Veg"
                        },
                        new
                        {
                            BurgerId = 9,
                            Name = "Cheesy Chilli",
                            Price = 150m,
                            Type = "Egg"
                        },
                        new
                        {
                            BurgerId = 10,
                            Name = "Cheesy Burger",
                            Price = 100m,
                            Type = "Veg"
                        },
                        new
                        {
                            BurgerId = 11,
                            Name = "Cheesy Burger",
                            Price = 200m,
                            Type = "Non-Veg"
                        },
                        new
                        {
                            BurgerId = 12,
                            Name = "Cheesy Burger",
                            Price = 150m,
                            Type = "Egg"
                        },
                        new
                        {
                            BurgerId = 13,
                            Name = "Cheesy Bonanza",
                            Price = 100m,
                            Type = "Veg"
                        },
                        new
                        {
                            BurgerId = 14,
                            Name = "Cheesy Bonanza",
                            Price = 200m,
                            Type = "Non-Veg"
                        },
                        new
                        {
                            BurgerId = 15,
                            Name = "Cheesy Bonanza",
                            Price = 150m,
                            Type = "Egg"
                        });
                });

            modelBuilder.Entity("BurgerManiaProject.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<bool>("Ordered")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BurgerManiaProject.Models.CartItems", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"));

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("BurgerId");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BurgerManiaProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BurgerManiaProject.Models.Cart", b =>
                {
                    b.HasOne("BurgerManiaProject.Models.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BurgerManiaProject.Models.CartItems", b =>
                {
                    b.HasOne("BurgerManiaProject.Models.Burger", "Burger")
                        .WithMany()
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BurgerManiaProject.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Burger");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("BurgerManiaProject.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("BurgerManiaProject.Models.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}