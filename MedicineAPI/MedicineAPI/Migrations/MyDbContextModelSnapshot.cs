﻿// <auto-generated />
using System;
using MedicineAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicineAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicineAPI.Data.DrUser", b =>
                {
                    b.Property<Guid>("idDrUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("emailDrUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullNameDrUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameDrUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("passwordDrUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneDrUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idDrUser");

                    b.ToTable("DrUser");
                });

            modelBuilder.Entity("MedicineAPI.Data.Medicine", b =>
                {
                    b.Property<Guid>("idMedicine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descriptionMedicine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idType")
                        .HasColumnType("int");

                    b.Property<string>("nameMedicine")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("idMedicine");

                    b.HasIndex("idType");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("MedicineAPI.Data.Prescription", b =>
                {
                    b.Property<Guid>("idPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("contentPrescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("drUseridDrUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("hourPrescription")
                        .HasColumnType("int");

                    b.Property<Guid>("idDrUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idMedicine")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("medicineidMedicine")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("minutePrescription")
                        .HasColumnType("int");

                    b.Property<double>("quantityPrescription")
                        .HasColumnType("float");

                    b.HasKey("idPrescription");

                    b.HasIndex("drUseridDrUser");

                    b.HasIndex("medicineidMedicine");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("MedicineAPI.Data.Type", b =>
                {
                    b.Property<int>("idType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nameType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idType");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("MedicineAPI.Data.User", b =>
                {
                    b.Property<Guid>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("emailUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullNameUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("passwordUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MedicineAPI.Data.Medicine", b =>
                {
                    b.HasOne("MedicineAPI.Data.Type", "type")
                        .WithMany("Medicines")
                        .HasForeignKey("idType");

                    b.Navigation("type");
                });

            modelBuilder.Entity("MedicineAPI.Data.Prescription", b =>
                {
                    b.HasOne("MedicineAPI.Data.DrUser", "drUser")
                        .WithMany("prescriptions")
                        .HasForeignKey("drUseridDrUser");

                    b.HasOne("MedicineAPI.Data.Medicine", "medicine")
                        .WithMany("prescriptions")
                        .HasForeignKey("medicineidMedicine");

                    b.Navigation("drUser");

                    b.Navigation("medicine");
                });

            modelBuilder.Entity("MedicineAPI.Data.DrUser", b =>
                {
                    b.Navigation("prescriptions");
                });

            modelBuilder.Entity("MedicineAPI.Data.Medicine", b =>
                {
                    b.Navigation("prescriptions");
                });

            modelBuilder.Entity("MedicineAPI.Data.Type", b =>
                {
                    b.Navigation("Medicines");
                });
#pragma warning restore 612, 618
        }
    }
}
