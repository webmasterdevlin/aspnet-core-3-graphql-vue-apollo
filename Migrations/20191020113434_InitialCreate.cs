using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreVueStarter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("b75b9284-95df-4ad7-b5fa-accff0effff3"), "John Doe's address", "John Doe" },
                    { new Guid("fab26154-d97e-4657-83ab-a0769340b978"), "Jane Doe's address", "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[,]
                {
                    { new Guid("05827dca-5e88-4449-a765-c4df53f3e267"), "Cash account for our users", new Guid("b75b9284-95df-4ad7-b5fa-accff0effff3"), 0 },
                    { new Guid("8dfe12d9-9688-42c9-9d6b-fc38e32c03da"), "Savings account for our users", new Guid("fab26154-d97e-4657-83ab-a0769340b978"), 1 },
                    { new Guid("1de3a0bb-8f1d-4f4d-a9b5-430d8adb1376"), "Income account for our users", new Guid("fab26154-d97e-4657-83ab-a0769340b978"), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
