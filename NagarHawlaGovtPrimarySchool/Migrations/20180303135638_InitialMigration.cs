using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NagarHawlaGovtPrimarySchool.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admitted",
                columns: table => new
                {
                    AdmissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: false),
                    FatherDOB = table.Column<DateTime>(nullable: false),
                    FatherMobile = table.Column<string>(nullable: false),
                    FatherNID = table.Column<int>(nullable: false),
                    FatherName = table.Column<string>(nullable: false),
                    FormNo = table.Column<int>(nullable: false),
                    HomeOwnerMobile = table.Column<string>(nullable: true),
                    HomeOwnerName = table.Column<string>(nullable: true),
                    MaternalGrandFatherName = table.Column<string>(nullable: false),
                    MaternalGrandMotherName = table.Column<string>(nullable: false),
                    MotherDOB = table.Column<DateTime>(nullable: false),
                    MotherMobile = table.Column<string>(nullable: false),
                    MotherNID = table.Column<int>(nullable: false),
                    MotherName = table.Column<string>(nullable: false),
                    PaternalGrandFatherName = table.Column<string>(nullable: false),
                    PaternalGrandMotherName = table.Column<string>(nullable: false),
                    PremanentDistrict = table.Column<string>(nullable: false),
                    PremanentPost = table.Column<string>(nullable: false),
                    PremanentPostCode = table.Column<string>(nullable: false),
                    PremanentSubDistrict = table.Column<string>(nullable: false),
                    PremanentVillage = table.Column<string>(nullable: false),
                    PresentDistrict = table.Column<string>(nullable: false),
                    PresentPost = table.Column<string>(nullable: false),
                    PresentPostCode = table.Column<string>(nullable: false),
                    PresentSubDistrict = table.Column<string>(nullable: false),
                    PresentVillage = table.Column<string>(nullable: false),
                    StudentBirthCertificateNo = table.Column<int>(nullable: false),
                    StudentDOB = table.Column<DateTime>(nullable: false),
                    StudentNameBangla = table.Column<string>(nullable: false),
                    StudentNameEnglish = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admitted", x => x.AdmissionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountType = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admitted");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
