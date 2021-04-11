using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORRA.Infrastructure.Persistence.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Departments_DepartmentId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonTitle_TitleId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Sites_BaseSiteId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_People_TitleId",
                table: "Contacts",
                newName: "IX_Contacts_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_People_DepartmentId",
                table: "Contacts",
                newName: "IX_Contacts_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_People_BaseSiteId",
                table: "Contacts",
                newName: "IX_Contacts_BaseSiteId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseSiteId",
                table: "Contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Departments_DepartmentId",
                table: "Contacts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Departments_DepartmentId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PersonTitle_TitleId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Sites_BaseSiteId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "People");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_TitleId",
                table: "People",
                newName: "IX_People_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_DepartmentId",
                table: "People",
                newName: "IX_People_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_BaseSiteId",
                table: "People",
                newName: "IX_People_BaseSiteId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "People",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseSiteId",
                table: "People",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

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
    }
}
