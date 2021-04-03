﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORRA.Infrastructure.Persistence;

namespace ORRA.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("ORRA.Domain.Entities.ImagingProcedure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CrisCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Interventional")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModalityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Term")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModalityId");

                    b.ToTable("ImagingProcedures");
                });

            modelBuilder.Entity("ORRA.Domain.Entities.Modality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModalityCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModalityName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModalityCode");

                    b.ToTable("Modalities");
                });

            modelBuilder.Entity("ORRA.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ORRA.Domain.Entities.ImagingProcedure", b =>
                {
                    b.HasOne("ORRA.Domain.Entities.Modality", "Modality")
                        .WithMany("ImagingProcedures")
                        .HasForeignKey("ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modality");
                });

            modelBuilder.Entity("ORRA.Domain.Entities.Modality", b =>
                {
                    b.Navigation("ImagingProcedures");
                });
#pragma warning restore 612, 618
        }
    }
}