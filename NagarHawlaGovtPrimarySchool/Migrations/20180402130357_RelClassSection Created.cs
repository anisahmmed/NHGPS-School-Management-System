using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NagarHawlaGovtPrimarySchool.Migrations
{
    public partial class RelClassSectionCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelClassSections_Classes_class_id1",
                table: "RelClassSections");

            migrationBuilder.DropForeignKey(
                name: "FK_RelClassSections_Sections_sec_id1",
                table: "RelClassSections");

            migrationBuilder.DropIndex(
                name: "IX_RelClassSections_class_id1",
                table: "RelClassSections");

            migrationBuilder.DropIndex(
                name: "IX_RelClassSections_sec_id1",
                table: "RelClassSections");

            migrationBuilder.DropColumn(
                name: "class_id1",
                table: "RelClassSections");

            migrationBuilder.DropColumn(
                name: "sec_id1",
                table: "RelClassSections");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RelClassSections",
                newName: "ClassSectionId");

            migrationBuilder.AddColumn<int>(
                name: "RelClassSectionClassSectionId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelClassSectionClassSectionId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_RelClassSectionClassSectionId",
                table: "Sections",
                column: "RelClassSectionClassSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_RelClassSectionClassSectionId",
                table: "Classes",
                column: "RelClassSectionClassSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_RelClassSections_RelClassSectionClassSectionId",
                table: "Classes",
                column: "RelClassSectionClassSectionId",
                principalTable: "RelClassSections",
                principalColumn: "ClassSectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_RelClassSections_RelClassSectionClassSectionId",
                table: "Sections",
                column: "RelClassSectionClassSectionId",
                principalTable: "RelClassSections",
                principalColumn: "ClassSectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_RelClassSections_RelClassSectionClassSectionId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_RelClassSections_RelClassSectionClassSectionId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_RelClassSectionClassSectionId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Classes_RelClassSectionClassSectionId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "RelClassSectionClassSectionId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "RelClassSectionClassSectionId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassSectionId",
                table: "RelClassSections",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "class_id1",
                table: "RelClassSections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sec_id1",
                table: "RelClassSections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RelClassSections_class_id1",
                table: "RelClassSections",
                column: "class_id1");

            migrationBuilder.CreateIndex(
                name: "IX_RelClassSections_sec_id1",
                table: "RelClassSections",
                column: "sec_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_RelClassSections_Classes_class_id1",
                table: "RelClassSections",
                column: "class_id1",
                principalTable: "Classes",
                principalColumn: "class_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelClassSections_Sections_sec_id1",
                table: "RelClassSections",
                column: "sec_id1",
                principalTable: "Sections",
                principalColumn: "sec_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
