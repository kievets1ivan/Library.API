using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class UDK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "QuestionAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Udks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Annotation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Udks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_UserId",
                table: "QuestionAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Udks_UserId",
                table: "Udks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_AspNetUsers_UserId",
                table: "QuestionAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_AspNetUsers_UserId",
                table: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "Udks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_UserId",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuestionAnswers");
        }
    }
}
