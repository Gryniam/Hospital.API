﻿// <auto-generated />
using System;
using Hospital.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital.API.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital.API.Models.Entities.Allergy", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("patiendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("substanceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("allergiesTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Analys", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("additionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("caseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("officeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("analysTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Appoiment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("doctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("officeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("patientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("timeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("appoimentTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Case", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("anamnesis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("caseStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("diseaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("doctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("officeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("patientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("treatmentInformation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("caseTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.CaseStatus", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("statusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("casesStatusTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Departament", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("additionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("hospitalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("departamentTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Disease", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("diseaseTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.District", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("regionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("districtTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Doctor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("additionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("doctorTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Gender", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("genderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("genderTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Hospital", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("adressDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("districtId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("regionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("settlementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("hospitalTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Indexes", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("additionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bloodPressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("bloodSugar")
                        .HasColumnType("real");

                    b.Property<float>("bodyTemperature")
                        .HasColumnType("real");

                    b.Property<float>("height")
                        .HasColumnType("real");

                    b.Property<Guid>("patiendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("pulse")
                        .HasColumnType("int");

                    b.Property<float>("weight")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("indexesTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Office", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("additionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberInHospital")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("officeTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Offices", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("departamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("officeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("officesTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Patient", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("patientTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Preparation", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("preparationTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Preparations", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("preparationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("substanceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("preparationsTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Region", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("regionTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Settlement", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("districtId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("settlementTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Specialities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("doctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("specialityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("specialitiesTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Specialty", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("specialityTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Status", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("statusTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Substance", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("substanceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("substanceTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Symptom", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("symptomTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Symptoms", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("diseaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("symptomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("symptomsTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Time", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("doctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("timeTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Treatment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("caseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("preparationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("treatmentTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Type", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("typeTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("genderId")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("settlementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userPictureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("userTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.UserPicture", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("userPictureTable");
                });

            modelBuilder.Entity("Hospital.API.Models.Entities.Work", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("departamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("doctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("hospitalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isAdminInDepartament")
                        .HasColumnType("bit");

                    b.Property<bool>("isAdminInHospital")
                        .HasColumnType("bit");

                    b.Property<int>("statusId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("workTable");
                });
#pragma warning restore 612, 618
        }
    }
}
