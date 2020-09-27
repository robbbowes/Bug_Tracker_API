using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bugtrackerapi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    BreakageReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fixes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    HowFixed = table.Column<string>(nullable: true),
                    BreakageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixes_Breakages_BreakageId",
                        column: x => x.BreakageId,
                        principalTable: "Breakages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Breakages",
                columns: new[] { "Id", "BreakageReason", "Date" },
                values: new object[] { 1, "Timeout Exception", new DateTime(2020, 9, 27, 16, 23, 21, 683, DateTimeKind.Local).AddTicks(2875) });

            migrationBuilder.InsertData(
                table: "Breakages",
                columns: new[] { "Id", "BreakageReason", "Date" },
                values: new object[] { 2, "Stale Element Exception", new DateTime(2020, 9, 27, 16, 23, 21, 683, DateTimeKind.Local).AddTicks(3540) });

            migrationBuilder.InsertData(
                table: "Fixes",
                columns: new[] { "Id", "BreakageId", "Date", "HowFixed" },
                values: new object[] { 1, 1, new DateTime(2020, 9, 27, 16, 23, 21, 678, DateTimeKind.Local).AddTicks(4413), "Added wait" });

            migrationBuilder.InsertData(
                table: "Fixes",
                columns: new[] { "Id", "BreakageId", "Date", "HowFixed" },
                values: new object[] { 2, 2, new DateTime(2020, 9, 27, 16, 23, 21, 682, DateTimeKind.Local).AddTicks(1284), "Updated CSS Selector" });

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_BreakageId",
                table: "Fixes",
                column: "BreakageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixes");

            migrationBuilder.DropTable(
                name: "Breakages");
        }
    }
}
