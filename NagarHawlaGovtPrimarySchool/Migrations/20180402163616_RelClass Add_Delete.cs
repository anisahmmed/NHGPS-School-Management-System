using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NagarHawlaGovtPrimarySchool.Migrations
{
    public partial class RelClassAdd_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelClassclass_id",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelClassclass_id",
                table: "Sections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_RelClassclass_id",
                table: "Subjects",
                column: "RelClassclass_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_RelClassclass_id",
                table: "Sections",
                column: "RelClassclass_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_RelClasses_RelClassclass_id",
                table: "Sections",
                column: "RelClassclass_id",
                principalTable: "RelClasses",
                principalColumn: "class_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_RelClasses_RelClassclass_id",
                table: "Subjects",
                column: "RelClassclass_id",
                principalTable: "RelClasses",
                principalColumn: "class_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_RelClasses_RelClassclass_id",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_RelClasses_RelClassclass_id",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_RelClassclass_id",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Sections_RelClassclass_id",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "RelClassclass_id",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "RelClassclass_id",
                table: "Sections");
        }
    }
}
