using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NagarHawlaGovtPrimarySchool.Migrations 
{
    public partial class RelClassCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Sections_RelSubjectSectionSubjectSectionId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "RelSubjectSectionSubjectSectionId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "RelSubjectSectionSubjectSectionId",
                table: "Sections");

            migrationBuilder.CreateTable(
                name: "RelClasses",
                columns: table => new
                {
                    class_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelClasses", x => x.class_id);
                });

            migrationBuilder.CreateTable(
                name: "RelClassSections",
                columns: table => new
                {
                    class_section_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelClassclass_id = table.Column<int>(nullable: true),
                    class_name = table.Column<string>(nullable: false),
                    section_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelClassSections", x => x.class_section_id);
                    table.ForeignKey(
                        name: "FK_RelClassSections_RelClasses_RelClassclass_id",
                        column: x => x.RelClassclass_id,
                        principalTable: "RelClasses",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelClassSubjects",
                columns: table => new
                {
                    class_subect_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelClassclass_id = table.Column<int>(nullable: true),
                    class_name = table.Column<string>(nullable: false),
                    subject_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelClassSubjects", x => x.class_subect_id);
                    table.ForeignKey(
                        name: "FK_RelClassSubjects_RelClasses_RelClassclass_id",
                        column: x => x.RelClassclass_id,
                        principalTable: "RelClasses",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelClassSections_RelClassclass_id",
                table: "RelClassSections",
                column: "RelClassclass_id");

            migrationBuilder.CreateIndex(
                name: "IX_RelClassSubjects_RelClassclass_id",
                table: "RelClassSubjects",
                column: "RelClassclass_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelClassSections");

            migrationBuilder.DropTable(
                name: "RelClassSubjects");

            migrationBuilder.DropTable(
                name: "RelClasses");

            migrationBuilder.AddColumn<int>(
                name: "RelSubjectSectionSubjectSectionId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelSubjectSectionSubjectSectionId",
                table: "Sections",
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

            migrationBuilder.CreateIndex(
                name: "IX_Sections_RelSubjectSectionSubjectSectionId",
                table: "Sections",
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
    }
}
