using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment2DanielaOnici.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_Invitations_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId");
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "PartyId", "Description", "EventDate", "Location" },
                values: new object[,]
                {
                    { 1, "New year's eve blast!!", new DateTime(2022, 12, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), "Times Square, NY" },
                    { 2, "Drinks at Moe's Bar", new DateTime(2022, 10, 30, 4, 43, 0, 0, DateTimeKind.Unspecified), "Moe's Bar, Springfield" },
                    { 3, "Thanksgiving gathering", new DateTime(2022, 10, 20, 4, 43, 0, 0, DateTimeKind.Unspecified), "Springfield" }
                });

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "InvitationId", "Email", "GuestName", "PartyId", "Status" },
                values: new object[,]
                {
                    { 1, "danielaonici@gmail.com", "Daniela Onici", 1, "InvitationSent" },
                    { 2, "gloria@gmail.com", "Gloria", 1, "RespondedNo" },
                    { 3, "boa@gmail.com", "Boa", 1, "InvitationNotSent" },
                    { 4, "gabriela@gmail.com", "Gabriela", 1, "RespondedYes" },
                    { 5, "luiz@gmail.com", "Luiz", 2, "InvitationSent" },
                    { 6, "danielaonici@gmail.com", "Daniela Onici", 3, "InvitationSent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_PartyId",
                table: "Invitations",
                column: "PartyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
