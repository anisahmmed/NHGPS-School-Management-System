using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NagarHawlaGovtPrimarySchool.Migrations
{
    public partial class RelclasssReults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelResults_Students_student_idAdmissionId",
                table: "RelResults");

            migrationBuilder.DropIndex(
                name: "IX_RelResults_student_idAdmissionId",
                table: "RelResults");

            migrationBuilder.DropColumn(
                name: "student_idAdmissionId",
                table: "RelResults");

            migrationBuilder.AddColumn<string>(
                name: "student_id",
                table: "RelResults",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "student_id",
                table: "RelResults");

            migrationBuilder.AddColumn<int>(
                name: "student_idAdmissionId",
                table: "RelResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RelResults_student_idAdmissionId",
                table: "RelResults",
                column: "student_idAdmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RelResults_Students_student_idAdmissionId",
                table: "RelResults",
                column: "student_idAdmissionId",
                principalTable: "Students",
                principalColumn: "AdmissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
