using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORRA.Infrastructure.Persistence.Migrations
{
    public partial class NewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagingProcedures_Modalities_ModalityId",
                table: "ImagingProcedures");

            migrationBuilder.DropTable(
                name: "Modalities");

            migrationBuilder.RenameColumn(
                name: "Term",
                table: "ImagingProcedures",
                newName: "ShortCode");

            migrationBuilder.RenameColumn(
                name: "Interventional",
                table: "ImagingProcedures",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ExamCount",
                table: "ImagingProcedures",
                newName: "IsInterventional");

            migrationBuilder.RenameColumn(
                name: "CrisCode",
                table: "ImagingProcedures",
                newName: "SNOMEDCT_LateralityID");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseSiteId",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelephoneNumber",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ImagingProcedures",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BodyPartMultiplicationFactor",
                table: "ImagingProcedures",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DisplayTerm",
                table: "ImagingProcedures",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeprecated",
                table: "ImagingProcedures",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiagnostic",
                table: "ImagingProcedures",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RecommendedSubstituteProcedure",
                table: "ImagingProcedures",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SNOMEDCT_ConceptID",
                table: "ImagingProcedures",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SNOMEDCT_FSN",
                table: "ImagingProcedures",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImagingModalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModalityCode = table.Column<string>(type: "TEXT", nullable: true),
                    ModalityName = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagingModalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Abbreviation = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AbriviatedTitle = table.Column<string>(type: "TEXT", nullable: true),
                    FullTitle = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: true),
                    Acronym = table.Column<string>(type: "TEXT", nullable: true),
                    OrganisationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SiteName = table.Column<string>(type: "TEXT", nullable: true),
                    SiteCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsMainSite = table.Column<bool>(type: "INTEGER", nullable: false),
                    Address_Line1 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Line2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_County = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_BaseSiteId",
                table: "People",
                column: "BaseSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DepartmentId",
                table: "People",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_People_TitleId",
                table: "People",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganisationId",
                table: "Departments",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagingModalities_ModalityCode",
                table: "ImagingModalities",
                column: "ModalityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DepartmentId",
                table: "Sites",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagingProcedures_ImagingModalities_ModalityId",
                table: "ImagingProcedures",
                column: "ModalityId",
                principalTable: "ImagingModalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Departments_DepartmentId",
                table: "People",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_PersonTitle_TitleId",
                table: "People",
                column: "TitleId",
                principalTable: "PersonTitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Sites_BaseSiteId",
                table: "People",
                column: "BaseSiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagingProcedures_ImagingModalities_ModalityId",
                table: "ImagingProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Departments_DepartmentId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonTitle_TitleId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Sites_BaseSiteId",
                table: "People");

            migrationBuilder.DropTable(
                name: "ImagingModalities");

            migrationBuilder.DropTable(
                name: "PersonTitle");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_People_BaseSiteId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DepartmentId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_TitleId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "BaseSiteId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "People");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "People");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TelephoneNumber",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "BodyPartMultiplicationFactor",
                table: "ImagingProcedures");

            migrationBuilder.DropColumn(
                name: "DisplayTerm",
                table: "ImagingProcedures");

            migrationBuilder.DropColumn(
                name: "IsDeprecated",
                table: "ImagingProcedures");

            migrationBuilder.DropColumn(
                name: "IsDiagnostic",
                table: "ImagingProcedures");

            migrationBuilder.DropColumn(
                name: "RecommendedSubstituteProcedure",
                table: "ImagingProcedures");

            migrationBuilder.DropColumn(
                name: "SNOMEDCT_ConceptID",
                table: "ImagingProcedures");

            migrationBuilder.DropColumn(
                name: "SNOMEDCT_FSN",
                table: "ImagingProcedures");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ImagingProcedures",
                newName: "Interventional");

            migrationBuilder.RenameColumn(
                name: "ShortCode",
                table: "ImagingProcedures",
                newName: "Term");

            migrationBuilder.RenameColumn(
                name: "SNOMEDCT_LateralityID",
                table: "ImagingProcedures",
                newName: "CrisCode");

            migrationBuilder.RenameColumn(
                name: "IsInterventional",
                table: "ImagingProcedures",
                newName: "ExamCount");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ImagingProcedures",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Modalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModalityCode = table.Column<string>(type: "TEXT", nullable: true),
                    ModalityName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modalities_ModalityCode",
                table: "Modalities",
                column: "ModalityCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagingProcedures_Modalities_ModalityId",
                table: "ImagingProcedures",
                column: "ModalityId",
                principalTable: "Modalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
