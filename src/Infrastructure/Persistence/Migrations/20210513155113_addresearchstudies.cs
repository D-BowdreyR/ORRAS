using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORRAS.Infrastructure.Persistence.Migrations
{
    public partial class addresearchstudies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResearchStudies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalPID = table.Column<string>(type: "text", nullable: true),
                    IrasProjectID = table.Column<string>(type: "text", nullable: true),
                    EudraCTReference = table.Column<string>(type: "text", nullable: true),
                    HRAReference = table.Column<string>(type: "text", nullable: true),
                    ShortTitle = table.Column<string>(type: "text", nullable: true),
                    Acronym = table.Column<string>(type: "text", nullable: true),
                    LongTitle = table.Column<string>(type: "text", nullable: true),
                    EstimatedStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EstimatedTotalDurationInMonths = table.Column<float>(type: "real", nullable: false),
                    IsInvolvingMedicalDeviceTrial = table.Column<bool>(type: "boolean", nullable: false),
                    IsInvolvingRadiotherapy = table.Column<bool>(type: "boolean", nullable: false),
                    IsInvolvingRadioactiveSubstances = table.Column<bool>(type: "boolean", nullable: false),
                    IsMultiCentre = table.Column<bool>(type: "boolean", nullable: false),
                    NumberOfUKCentres = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchStudies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchStudies");
        }
    }
}
