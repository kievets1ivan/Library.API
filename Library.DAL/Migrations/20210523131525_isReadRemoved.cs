using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class isReadRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReadAnswerByUser",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "IsReadQuestionByAdmin",
                table: "QuestionAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReadAnswerByUser",
                table: "QuestionAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadQuestionByAdmin",
                table: "QuestionAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
