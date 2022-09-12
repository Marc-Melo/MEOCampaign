﻿// <auto-generated />
using System;
using MEOCampaign.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MEOCampaign.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220911235354_InitialCreate_v1")]
    partial class InitialCreate_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MEOCampaign.Core.Entities.Citizen", b =>
                {
                    b.Property<int>("CitizenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitizenId"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CitizenId");

                    b.ToTable("Citizens");
                });

            modelBuilder.Entity("MEOCampaign.Core.Entities.CitizenAddress", b =>
                {
                    b.Property<int>("CitizenAddressId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CitizenAddressId");

                    b.ToTable("CitizenAddresses");
                });

            modelBuilder.Entity("MEOCampaign.Core.Entities.CitizenAddress", b =>
                {
                    b.HasOne("MEOCampaign.Core.Entities.Citizen", "Citizen")
                        .WithOne("CitizenAddress")
                        .HasForeignKey("MEOCampaign.Core.Entities.CitizenAddress", "CitizenAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citizen");
                });

            modelBuilder.Entity("MEOCampaign.Core.Entities.Citizen", b =>
                {
                    b.Navigation("CitizenAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
