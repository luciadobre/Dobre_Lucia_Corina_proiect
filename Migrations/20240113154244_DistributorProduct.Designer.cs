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
    [Migration("20240113154244_DistributorProduct")]
    partial class DistributorProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("DistributorID")
                        .HasColumnType("int");

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

                    b.Property<string>("DistributorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SellDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("ID");

                    b.HasIndex("DistributorID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.DistributorProduct", b =>
                {
                    b.HasOne("Dobre_Lucia_Corina_proiect.Models.Distributor", "Distributor")
                        .WithMany()
                        .HasForeignKey("DistributorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Product", b =>
                {
                    b.HasOne("Dobre_Lucia_Corina_proiect.Models.Distributor", "Distributor")
                        .WithMany("Product")
                        .HasForeignKey("DistributorID");

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("Dobre_Lucia_Corina_proiect.Models.Distributor", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
