using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class iniu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GreenHouseManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GreenHouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreenHouseManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GreenHouseManager_GreenHouses_GreenHouseId",
                        column: x => x.GreenHouseId,
                        principalTable: "GreenHouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GreenHouseManager_GreenHouseId",
                table: "GreenHouseManager",
                column: "GreenHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GreenHouseManager");
        }
    }
}
