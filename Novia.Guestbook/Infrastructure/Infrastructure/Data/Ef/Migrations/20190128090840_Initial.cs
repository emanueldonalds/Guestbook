using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novia.Guestbook.Infrastructure.Data.Ef.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guestbooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guestbooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestbookEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    DateTimeCreated = table.Column<DateTimeOffset>(nullable: false),
                    BelongsToId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestbookEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestbookEntries_Guestbooks_BelongsToId",
                        column: x => x.BelongsToId,
                        principalTable: "Guestbooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestbookEntries_BelongsToId",
                table: "GuestbookEntries",
                column: "BelongsToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestbookEntries");

            migrationBuilder.DropTable(
                name: "Guestbooks");
        }
    }
}
