﻿// <auto-generated />
using System;
using DHI_Challenges.Services.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DHI_Challenges.Services.Migrations
{
    [DbContext(typeof(DHIContexts))]
    [Migration("20250127000453_addquantity")]
    partial class addquantity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DHI_Challenges.Models.Entities.MasterProduct", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductID");

                    b.ToTable("MasterProducts", "Product");
                });

            modelBuilder.Entity("DHI_Challenges.Models.Entities.MasterUser", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserID");

                    b.ToTable("MasterUsers", "User");
                });

            modelBuilder.Entity("DHI_Challenges.Models.Entities.TransactionDetail", b =>
                {
                    b.Property<int>("DetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailID"));

                    b.Property<int>("HeaderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DetailID");

                    b.HasIndex("HeaderID");

                    b.HasIndex("ProductID");

                    b.ToTable("Details", "Transaction");
                });

            modelBuilder.Entity("DHI_Challenges.Models.Entities.TransactionHeader", b =>
                {
                    b.Property<int>("HeaderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HeaderID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("SummaryQuantity")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("HeaderID");

                    b.HasIndex("UserID");

                    b.ToTable("Headers", "Transaction");
                });

            modelBuilder.Entity("DHI_Challenges.Models.Entities.TransactionDetail", b =>
                {
                    b.HasOne("DHI_Challenges.Models.Entities.TransactionHeader", "TransactionHeader")
                        .WithMany()
                        .HasForeignKey("HeaderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DHI_Challenges.Models.Entities.MasterProduct", "MasterProducts")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterProducts");

                    b.Navigation("TransactionHeader");
                });

            modelBuilder.Entity("DHI_Challenges.Models.Entities.TransactionHeader", b =>
                {
                    b.HasOne("DHI_Challenges.Models.Entities.MasterUser", "MasterUsers")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
