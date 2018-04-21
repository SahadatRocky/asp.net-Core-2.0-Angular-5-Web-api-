﻿// <auto-generated />
using JobApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JobApplication.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180416215328_DeveloperJobMigration")]
    partial class DeveloperJobMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobApplication.Model.CompanyAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("CountryName");

                    b.Property<string>("State");

                    b.Property<string>("zipCode");

                    b.HasKey("Id");

                    b.ToTable("CompanyAddress");
                });

            modelBuilder.Entity("JobApplication.Model.CompanyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CompanyType");
                });

            modelBuilder.Entity("JobApplication.Model.DeveloperJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyAddressId");

                    b.Property<string>("CompanyName");

                    b.Property<int>("CompanySize");

                    b.Property<int>("CompanyTypeId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("DeactivatedDate");

                    b.Property<bool?>("EquitySharing");

                    b.Property<string>("ExperienceLavel");

                    b.Property<int>("IndustryId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobTitle");

                    b.Property<int>("JobTypeId");

                    b.Property<bool?>("RemoteOptions");

                    b.Property<string>("SalaryRange");

                    b.HasKey("Id");

                    b.HasIndex("CompanyAddressId");

                    b.HasIndex("CompanyTypeId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("JobTypeId");

                    b.ToTable("DeveloperJobs");
                });

            modelBuilder.Entity("JobApplication.Model.Industry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Industry");
                });

            modelBuilder.Entity("JobApplication.Model.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("JobType");
                });

            modelBuilder.Entity("JobApplication.Model.DeveloperJob", b =>
                {
                    b.HasOne("JobApplication.Model.CompanyAddress", "CompanyAddress")
                        .WithMany()
                        .HasForeignKey("CompanyAddressId");

                    b.HasOne("JobApplication.Model.CompanyType", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobApplication.Model.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobApplication.Model.JobType", "JobType")
                        .WithMany()
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}