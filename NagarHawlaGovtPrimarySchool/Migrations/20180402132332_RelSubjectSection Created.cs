using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NagarHawlaGovtPrimarySchool.Migrations
{
    public partial class RelSubjectSectionCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_RelClassSections_RelClassSectionClassSectionId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_RelClassSections_RelClassSectionClassSectionId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "RelClassSections");

            migrationBuilder.DropIndex(
                name: "IX_Classes_RelClassSectionClassSectionId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "RelClassSectionClassSectionId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "RelClassSectionClassSectionId",
                table: "Sections",
                newName: "RelSubjectSectionSubjectSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_RelClassSectionClassSectionId",
                table: "Sections",
                newName: "IX_Sections_RelSubjectSectionSubjectSectionId");

            migrationBuilder.AddColumn<int>(
                name: "RelSubjectSectionSubjectSectionId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RelSubjectSections",
                columns: table => new
                {
                    SubjectSectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelSubjectSections", x => x.SubjectSectionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_RelSubjectSectionSubjectSectionId",
                table: "Subjects",
                column: "RelSubjectSectionSubjectSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_RelSubjectSections_RelSubjectSectionSubjectSectionId",
                table: "Sections",
                column: "RelSubjectSectionSubjectSectionId",
                principalTable: "RelSubjectSections",
                principalColumn: "SubjectSectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_RelSubjectSections_RelSubjectSectionSubjectSectionId",
                table: "Subjects",
                column: "RelSubjectSectionSubjectSectionId",
                principalTable: "RelSubjectSections",
                principalColumn: "SubjectSectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_RelSubjectSections_RelSubjectSectionSubjectSectionId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_RelSubjectSections_RelSubjectSectionSubjectSectionId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "RelSubjectSections");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_RelSubjectSectionSubjectSectionId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "RelSubjectSectionSubjectSectionId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "RelSubjectSectionSubjectSectionId",
                table: "Sections",
                newName: "RelClassSectionClassSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_RelSubjectSectionSubjectSectionId",
                table: "Sections",
                newName: "IX_Sections_RelClassSectionClassSectionId");

            migrationBuilder.AddColumn<int>(
                name: "RelClassSectionClassSectionId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RelClassSections",
                columns: table => new
                {
                    ClassSectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelClassSections", x => x.ClassSectionId);
                });

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
    }
}
