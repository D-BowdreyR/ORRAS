using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORRA.Infrastructure.Persistence.Migrations
{
    public partial class removetitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTitles");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PersonTitles",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTitles", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_PersonTitles_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
