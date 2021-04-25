﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ORRAS.Infrastructure.Persistence;

namespace ORRAS.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210412213323_initialPosgres")]
    partial class initialPosgres
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ORRAS.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Qualification")
                        .HasColumnType("text");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Acronym")
                        .HasColumnType("text");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.ImagingModality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModalityCode")
                        .HasColumnType("text");

                    b.Property<string>("ModalityName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ModalityCode");

                    b.ToTable("ImagingModalities");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.ImagingProcedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BodyPartMultiplicationFactor")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayTerm")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeprecated")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDiagnostic")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsInterventional")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ModalityId")
                        .HasColumnType("uuid");

                    b.Property<string>("RecommendedSubstituteProcedure")
                        .HasColumnType("text");

                    b.Property<string>("SNOMEDCT_ConceptID")
                        .HasColumnType("text");

                    b.Property<string>("SNOMEDCT_FSN")
                        .HasColumnType("text");

                    b.Property<string>("SNOMEDCT_LateralityID")
                        .HasColumnType("text");

                    b.Property<string>("ShortCode")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModalityId");

                    b.ToTable("ImagingProcedures");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.Contact", b =>
                {
                    b.HasOne("ORRAS.Domain.Entities.Department", "Department")
                        .WithMany("Contacts")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.Department", b =>
                {
                    b.HasOne("ORRAS.Domain.Entities.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.ImagingProcedure", b =>
                {
                    b.HasOne("ORRAS.Domain.Entities.ImagingModality", "Modality")
                        .WithMany("ImagingProcedures")
                        .HasForeignKey("ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modality");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.Company", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.Department", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("ORRAS.Domain.Entities.ImagingModality", b =>
                {
                    b.Navigation("ImagingProcedures");
                });
#pragma warning restore 612, 618
        }
    }
}
