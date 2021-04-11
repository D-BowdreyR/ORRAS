using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORRA.Infrastructure.Persistence.Migrations
{
    public partial class justafewentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PersonTitle_TitleId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Sites_BaseSiteId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_BaseSiteId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_TitleId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonTitle",
                table: "PersonTitle");

            migrationBuilder.DropColumn(
                name: "BaseSiteId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonTitle");

            migrationBuilder.DropColumn(
                name: "AbriviatedTitle",
                table: "PersonTitle");

            migrationBuilder.RenameTable(
                name: "PersonTitle",
                newName: "PersonTitles");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "PersonTitles",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "FullTitle",
                table: "PersonTitles",
                newName: "Title");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "PersonTitles",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonTitles",
                table: "PersonTitles",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTitles_Contacts_ContactId",
                table: "PersonTitles",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTitles_Contacts_ContactId",
                table: "PersonTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonTitles",
                table: "PersonTitles");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "PersonTitles");

            migrationBuilder.RenameTable(
                name: "PersonTitles",
                newName: "PersonTitle");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "PersonTitle",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PersonTitle",
                newName: "FullTitle");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseSiteId",
                table: "Contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PersonTitle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "AbriviatedTitle",
                table: "PersonTitle",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonTitle",
                table: "PersonTitle",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsMainSite = table.Column<bool>(type: "INTEGER", nullable: false),
                    SiteCode = table.Column<string>(type: "TEXT", nullable: true),
                    SiteName = table.Column<string>(type: "TEXT", nullable: true),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: true),
                    Address_County = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Line1 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Line2 = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "IX_Contacts_BaseSiteId",
                table: "Contacts",
                column: "BaseSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TitleId",
                table: "Contacts",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DepartmentId",
                table: "Sites",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PersonTitle_TitleId",
                table: "Contacts",
                column: "TitleId",
                principalTable: "PersonTitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Sites_BaseSiteId",
                table: "Contacts",
                column: "BaseSiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
