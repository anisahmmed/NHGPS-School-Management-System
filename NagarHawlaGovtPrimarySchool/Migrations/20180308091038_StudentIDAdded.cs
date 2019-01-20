using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NagarHawlaGovtPrimarySchool.Migrations
{
    public partial class StudentIDAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PremanentVillage",
                table: "Admitted",
                newName: "PermanentVillage");

            migrationBuilder.RenameColumn(
                name: "PremanentSubDistrict",
                table: "Admitted",
                newName: "PermanentSubDistrict");

            migrationBuilder.RenameColumn(
                name: "PremanentPostCode",
                table: "Admitted",
                newName: "PermanentPostCode");

            migrationBuilder.RenameColumn(
                name: "PremanentPost",
                table: "Admitted",
                newName: "PermanentPost");

            migrationBuilder.RenameColumn(
                name: "PremanentDistrict",
                table: "Admitted",
                newName: "PermanentDistrict");

            migrationBuilder.AlterColumn<string>(
                name: "MotherNID",
                table: "Admitted",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MotherMobile",
                table: "Admitted",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FatherNID",
                table: "Admitted",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FatherMobile",
                table: "Admitted",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Admitted",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Admitted");

            migrationBuilder.RenameColumn(
                name: "PermanentVillage",
                table: "Admitted",
                newName: "PremanentVillage");

            migrationBuilder.RenameColumn(
                name: "PermanentSubDistrict",
                table: "Admitted",
                newName: "PremanentSubDistrict");

            migrationBuilder.RenameColumn(
                name: "PermanentPostCode",
                table: "Admitted",
                newName: "PremanentPostCode");

            migrationBuilder.RenameColumn(
                name: "PermanentPost",
                table: "Admitted",
                newName: "PremanentPost");

            migrationBuilder.RenameColumn(
                name: "PermanentDistrict",
                table: "Admitted",
                newName: "PremanentDistrict");

            migrationBuilder.AlterColumn<int>(
                name: "MotherNID",
                table: "Admitted",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "MotherMobile",
                table: "Admitted",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<int>(
                name: "FatherNID",
                table: "Admitted",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "FatherMobile",
                table: "Admitted",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
