﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NagarHawlaGovtPrimarySchool.Models;
using System;

namespace NagarHawlaGovtPrimarySchool.Migrations
{
    [DbContext(typeof(NHGPSContext))]
    [Migration("20180402150250_RelClass Created")]
    partial class RelClassCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.Admission", b =>
                {
                    b.Property<int>("AdmissionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName")
                        .IsRequired();

                    b.Property<DateTime>("FatherDOB");

                    b.Property<string>("FatherMobile")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<string>("FatherNID")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("FatherName")
                        .IsRequired();

                    b.Property<int>("FormNo");

                    b.Property<string>("HomeOwnerMobile");

                    b.Property<string>("HomeOwnerName");

                    b.Property<string>("MaternalGrandFatherName")
                        .IsRequired();

                    b.Property<string>("MaternalGrandMotherName")
                        .IsRequired();

                    b.Property<DateTime>("MotherDOB");

                    b.Property<string>("MotherMobile")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<string>("MotherNID")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("MotherName")
                        .IsRequired();

                    b.Property<string>("PaternalGrandFatherName")
                        .IsRequired();

                    b.Property<string>("PaternalGrandMotherName")
                        .IsRequired();

                    b.Property<string>("PermanentDistrict")
                        .IsRequired();

                    b.Property<string>("PermanentPost")
                        .IsRequired();

                    b.Property<string>("PermanentPostCode")
                        .IsRequired();

                    b.Property<string>("PermanentSubDistrict")
                        .IsRequired();

                    b.Property<string>("PermanentVillage")
                        .IsRequired();

                    b.Property<string>("PresentDistrict")
                        .IsRequired();

                    b.Property<string>("PresentPost")
                        .IsRequired();

                    b.Property<string>("PresentPostCode")
                        .IsRequired();

                    b.Property<string>("PresentSubDistrict")
                        .IsRequired();

                    b.Property<string>("PresentVillage")
                        .IsRequired();

                    b.Property<int>("StudentBirthCertificateNo");

                    b.Property<DateTime>("StudentDOB");

                    b.Property<int>("StudentId");

                    b.Property<string>("StudentNameBangla")
                        .IsRequired();

                    b.Property<string>("StudentNameEnglish")
                        .IsRequired();

                    b.HasKey("AdmissionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.Class", b =>
                {
                    b.Property<int>("class_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("class_name")
                        .IsRequired();

                    b.HasKey("class_id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.ExamType", b =>
                {
                    b.Property<int>("exam_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("exam_type")
                        .IsRequired();

                    b.HasKey("exam_id");

                    b.ToTable("ExamTypes");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.RelClass", b =>
                {
                    b.Property<int>("class_id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("class_id");

                    b.ToTable("RelClasses");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.RelClassSection", b =>
                {
                    b.Property<int>("class_section_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RelClassclass_id");

                    b.Property<string>("class_name")
                        .IsRequired();

                    b.Property<string>("section_name")
                        .IsRequired();

                    b.HasKey("class_section_id");

                    b.HasIndex("RelClassclass_id");

                    b.ToTable("RelClassSections");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.RelClassSubject", b =>
                {
                    b.Property<int>("class_subect_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RelClassclass_id");

                    b.Property<string>("class_name")
                        .IsRequired();

                    b.Property<string>("subject_name")
                        .IsRequired();

                    b.HasKey("class_subect_id");

                    b.HasIndex("RelClassclass_id");

                    b.ToTable("RelClassSubjects");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.Section", b =>
                {
                    b.Property<int>("sec_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("section")
                        .IsRequired();

                    b.HasKey("sec_id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.Subject", b =>
                {
                    b.Property<int>("sub_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("sub_code");

                    b.Property<string>("sub_name")
                        .IsRequired();

                    b.HasKey("sub_id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountType")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.RelClassSection", b =>
                {
                    b.HasOne("NagarHawlaGovtPrimarySchool.Models.RelClass")
                        .WithMany("SectionAll")
                        .HasForeignKey("RelClassclass_id");
                });

            modelBuilder.Entity("NagarHawlaGovtPrimarySchool.Models.RelClassSubject", b =>
                {
                    b.HasOne("NagarHawlaGovtPrimarySchool.Models.RelClass")
                        .WithMany("SubjectAll")
                        .HasForeignKey("RelClassclass_id");
                });
#pragma warning restore 612, 618
        }
    }
}
