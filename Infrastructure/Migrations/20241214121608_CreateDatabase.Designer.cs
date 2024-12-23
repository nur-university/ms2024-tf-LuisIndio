﻿// <auto-generated />
using System;
using Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StoredDbContext))]
    [Migration("20241214121608_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.StoredModel.Entities.AnalysisRequestModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("AnalysisRequestId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Date");

                    b.Property<string>("NutritionistId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NutritionistId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Status");

                    b.Property<string>("patientId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PatientId");

                    b.HasKey("Id");

                    b.ToTable("AnalysisRequest");
                });

            modelBuilder.Entity("Infrastructure.StoredModel.Entities.NutritionistModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("NutritionistId");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("FullName");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Specialization");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Nutritionist");
                });
#pragma warning restore 612, 618
        }
    }
}
