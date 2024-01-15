﻿// <auto-generated />
using System;
using Dobre_Lucia_Corina_proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dobre_Lucia_Corina_proiect.Migrations
{
    [DbContext(typeof(Dobre_Lucia_Corina_proiectContext))]
    [Migration("20240114192305_BuyersSalesModify")]
    partial class BuyersSalesModify
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Buyer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Buyer");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Distributor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistributorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Distributor");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.DistributorProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DistributorID")
                        .HasColumnType("int");

                    b.Property<string>("DistributorProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DistributorID");

                    b.ToTable("DistributorProduct");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistributorID")
                        .HasColumnType("int");

                    b.Property<int?>("DistributorProductID")
                        .HasColumnType("int");

                    b.Property<int?>("DistributorProductName")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("SellDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("ID");

                    b.HasIndex("DistributorID");

                    b.HasIndex("DistributorProductID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Sale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BuyerID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BuyerID");

                    b.HasIndex("ProductID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.DistributorProduct", b =>
                {
                    b.HasOne("Dobre_Lucia_Corina_proiect.Models.Distributor", "Distributor")
                        .WithMany("DistributorProduct")
                        .HasForeignKey("DistributorID");

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Product", b =>
                {
                    b.HasOne("Dobre_Lucia_Corina_proiect.Models.Distributor", "Distributor")
                        .WithMany()
                        .HasForeignKey("DistributorID");

                    b.HasOne("Dobre_Lucia_Corina_proiect.Models.DistributorProduct", "DistributorProduct")
                        .WithMany()
                        .HasForeignKey("DistributorProductID");

                    b.Navigation("Distributor");

                    b.Navigation("DistributorProduct");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Sale", b =>
                {
                    b.HasOne("Dobre_Lucia_Corina_proiect.Models.Buyer", "Buyer")
                        .WithMany("Sale")
                        .HasForeignKey("BuyerID");

                    b.HasOne("Dobre_Lucia_Corina_proiect.Models.Product", "Product")
                        .WithMany("Sale")
                        .HasForeignKey("ProductID");

                    b.Navigation("Buyer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Buyer", b =>
                {
                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Distributor", b =>
                {
                    b.Navigation("DistributorProduct");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Product", b =>
                {
                    b.Navigation("Sale");
                });
#pragma warning restore 612, 618
        }
    }
}