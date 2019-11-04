using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cards.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrimaryLang = table.Column<string>(nullable: true),
                    SecondaryLang = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepeatRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Word = table.Column<string>(nullable: false),
                    Meaning = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsSaved = table.Column<bool>(nullable: false),
                    ModeId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    RepeatRateId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Modes_ModeId",
                        column: x => x.ModeId,
                        principalTable: "Modes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_RepeatRates_RepeatRateId",
                        column: x => x.RepeatRateId,
                        principalTable: "RepeatRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Sort" },
                values: new object[,]
                {
                    { new Guid("a06d33df-fbee-4070-b839-65dcf47bac66"), "Word", 1 },
                    { new Guid("d7f051f2-eb2b-4c9b-be24-b894f4e1ca65"), "Phrase", 2 },
                    { new Guid("beedfe55-aada-4dc7-98ca-104052972d8b"), "Sentence", 3 }
                });

            migrationBuilder.InsertData(
                table: "Modes",
                columns: new[] { "Id", "PrimaryLang", "SecondaryLang", "Sort" },
                values: new object[,]
                {
                    { new Guid("40192768-f4bc-48c4-b396-fde50afd34ed"), "En", "Fr", 1 },
                    { new Guid("a437818d-89b6-4ba0-84d0-c8b9eb6856e1"), "Fr", "En", 2 }
                });

            migrationBuilder.InsertData(
                table: "RepeatRates",
                columns: new[] { "Id", "Name", "Sort" },
                values: new object[,]
                {
                    { new Guid("079a5f79-dd4c-44cc-bd8d-5f9f7ef4e3cb"), "Daily", 1 },
                    { new Guid("e1e223d6-e72e-445f-b55e-7ba6f1d3af9a"), "Two Days", 2 },
                    { new Guid("dfe0359c-5c64-47c5-90d9-693110c7e642"), "Three Days", 3 },
                    { new Guid("96eb9404-2fac-4567-b436-33bbf4fa1b2f"), "Weekly", 4 },
                    { new Guid("c4c29e70-6504-42e7-acef-f21130e476d9"), "Two Weeks", 5 },
                    { new Guid("5d2606bf-296e-42b0-8314-f4b76a3a6bdc"), "Monthly", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CategoryId",
                table: "Cards",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ModeId",
                table: "Cards",
                column: "ModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RepeatRateId",
                table: "Cards",
                column: "RepeatRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropTable(
                name: "RepeatRates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
