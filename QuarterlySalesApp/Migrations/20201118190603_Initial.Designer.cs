﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuarterlySalesApp.Models;

namespace QuarterlySalesApp.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20201118190603_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuarterlySalesApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfHire")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            DateOfBirth = new DateTime(1956, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ada",
                            LastName = "Lovelace",
                            ManagerID = 0
                        },
                        new
                        {
                            EmployeeID = 2,
                            DateOfBirth = new DateTime(1977, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Luigi",
                            LastName = "Verminelli",
                            ManagerID = 1
                        },
                        new
                        {
                            EmployeeID = 3,
                            DateOfBirth = new DateTime(1966, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Carl",
                            LastName = "Wheezer",
                            ManagerID = 1
                        });
                });

            modelBuilder.Entity("QuarterlySalesApp.Models.Sales", b =>
                {
                    b.Property<int>("SalesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("Quarter")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double?>("SalesAmount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SalesID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            SalesID = 1,
                            EmployeeID = 2,
                            Quarter = 4,
                            SalesAmount = 20100.0,
                            Year = 2019
                        },
                        new
                        {
                            SalesID = 2,
                            EmployeeID = 2,
                            Quarter = 1,
                            SalesAmount = 31211.0,
                            Year = 2020
                        },
                        new
                        {
                            SalesID = 3,
                            EmployeeID = 3,
                            Quarter = 2,
                            SalesAmount = 42322.0,
                            Year = 202020
                        });
                });

            modelBuilder.Entity("QuarterlySalesApp.Models.Sales", b =>
                {
                    b.HasOne("QuarterlySalesApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
