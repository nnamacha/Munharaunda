﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Munharaunda.Infrastructure.Database;

namespace Munharaunda.Infrastructure.Migrations
{
    [DbContext(typeof(MunharaundaDbContext))]
    [Migration("20210102054840_sp-GetFuneralsByProfile")]
    partial class SpGetFuneralsByProfile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Munharaunda.Domain.Models.Funeral", b =>
                {
                    b.Property<int>("FuneralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AddressForFuneral")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("DeceasedsProfileNumber")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("FuneralId");

                    b.ToTable("Funeral");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.IdentityTypes", b =>
                {
                    b.Property<int>("IdentityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdentityTypeId");

                    b.ToTable("IdentityTypes");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.Profile", b =>
                {
                    b.Property<int>("ProfileNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ActiveDate")
                        .HasColumnType("Date");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Approve1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve4")
                        .HasColumnType("datetime2");

                    b.Property<int>("Approver1")
                        .HasColumnType("int");

                    b.Property<int>("Approver2")
                        .HasColumnType("int");

                    b.Property<int>("Approver3")
                        .HasColumnType("int");

                    b.Property<int>("Approver4")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Date");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NextOfKin")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("ReOpen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReOpened")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReOpenedBy")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("ProfileNumber");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.ProfileTypes", b =>
                {
                    b.Property<int>("ProfileTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileTypeId");

                    b.ToTable("ProfileTypes");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.ReturnCodes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ReturnCodes");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.Statuses", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Approve1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve4")
                        .HasColumnType("datetime2");

                    b.Property<int>("Approver1")
                        .HasColumnType("int");

                    b.Property<int>("Approver2")
                        .HasColumnType("int");

                    b.Property<int>("Approver3")
                        .HasColumnType("int");

                    b.Property<int>("Approver4")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.StatusesHistory", b =>
                {
                    b.Property<int>("StatusHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Approve1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve4")
                        .HasColumnType("datetime2");

                    b.Property<int>("Approver1")
                        .HasColumnType("int");

                    b.Property<int>("Approver2")
                        .HasColumnType("int");

                    b.Property<int>("Approver3")
                        .HasColumnType("int");

                    b.Property<int>("Approver4")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("StatusHistoryId");

                    b.ToTable("StatusesHistory");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.TransactionCodes", b =>
                {
                    b.Property<int>("TransactionCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Contribution")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("Credit")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("TransactionCodeId");

                    b.ToTable("TransactionCodes");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.TransactionCodesHistory", b =>
                {
                    b.Property<int>("TransactionCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Contribution")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("Credit")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("TransactionCodeId");

                    b.ToTable("TransactionCodesHistory");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.Transactions", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Approve1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve4")
                        .HasColumnType("datetime2");

                    b.Property<int>("Approver1")
                        .HasColumnType("int");

                    b.Property<int>("Approver2")
                        .HasColumnType("int");

                    b.Property<int>("Approver3")
                        .HasColumnType("int");

                    b.Property<int>("Approver4")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Contribution")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("FuneralId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TransactionCode")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Munharaunda.Domain.Models.TransactionsArchive", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Approve1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve3")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Approve4")
                        .HasColumnType("datetime2");

                    b.Property<int>("Approver1")
                        .HasColumnType("int");

                    b.Property<int>("Approver2")
                        .HasColumnType("int");

                    b.Property<int>("Approver3")
                        .HasColumnType("int");

                    b.Property<int>("Approver4")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("FuneralId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TransactionCode")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.ToTable("TransactionsArchive");
                });
#pragma warning restore 612, 618
        }
    }
}
