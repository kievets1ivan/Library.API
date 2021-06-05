using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class publicationsForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Periods_PublicationPeriods_PublicationPeriodsId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Periods_PeriodId",
                table: "Publications");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationPeriodsId",
                table: "Periods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_PublicationPeriods_PublicationPeriodsId",
                table: "Periods",
                column: "PublicationPeriodsId",
                principalTable: "PublicationPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Periods_PeriodId",
                table: "Publications",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Periods_PublicationPeriods_PublicationPeriodsId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Periods_PeriodId",
                table: "Publications");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "Publications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationPeriodsId",
                table: "Periods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_PublicationPeriods_PublicationPeriodsId",
                table: "Periods",
                column: "PublicationPeriodsId",
                principalTable: "PublicationPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Periods_PeriodId",
                table: "Publications",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
