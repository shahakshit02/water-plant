using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Water_plant_BackEnd.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterPlantDetails",
                columns: table => new
                {
                    pId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    waterStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    waterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isWatering = table.Column<bool>(type: "bit", nullable: false),
                    waterInterval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterPlantDetails", x => x.pId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterPlantDetails");
        }
    }
}
