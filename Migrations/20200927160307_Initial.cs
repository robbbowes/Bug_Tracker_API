using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bugtrackerapi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    IsBroken = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breakages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    BreakageReason = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breakages_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Tests",
                columns: new[] { "Id", "IsBroken", "Name" },
                values: new object[] { 1, true, "Test A" });

            migrationBuilder.InsertData(
                table: "Breakages",
                columns: new[] { "Id", "BreakageReason", "Date", "TestId" },
                values: new object[] { 1, "Timeout Exception", new DateTime(2020, 9, 27, 18, 3, 7, 550, DateTimeKind.Local).AddTicks(806), 1 });

            migrationBuilder.InsertData(
                table: "Breakages",
                columns: new[] { "Id", "BreakageReason", "Date", "TestId" },
                values: new object[] { 2, "Stale Element Exception", new DateTime(2020, 9, 27, 18, 3, 7, 550, DateTimeKind.Local).AddTicks(1690), 1 });

            migrationBuilder.InsertData(
                table: "Breakages",
                columns: new[] { "Id", "BreakageReason", "Date", "TestId" },
                values: new object[] { 3, "Stale Element Exception", new DateTime(2020, 9, 27, 18, 3, 7, 550, DateTimeKind.Local).AddTicks(1730), 1 });

            migrationBuilder.InsertData(
                table: "Fixes",
                columns: new[] { "Id", "BreakageId", "Date", "HowFixed" },
                values: new object[] { 1, 1, new DateTime(2020, 9, 27, 18, 3, 7, 545, DateTimeKind.Local).AddTicks(6089), "Added wait" });

            migrationBuilder.InsertData(
                table: "Fixes",
                columns: new[] { "Id", "BreakageId", "Date", "HowFixed" },
                values: new object[] { 2, 2, new DateTime(2020, 9, 27, 18, 3, 7, 548, DateTimeKind.Local).AddTicks(9753), "Updated CSS Selector" });

            migrationBuilder.CreateIndex(
                name: "IX_Breakages_TestId",
                table: "Breakages",
                column: "TestId");

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

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
