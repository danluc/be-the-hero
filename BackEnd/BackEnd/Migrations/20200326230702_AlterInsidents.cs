using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class AlterInsidents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Ongs_OngId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_OngId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "OngId",
                table: "Incidents");

            migrationBuilder.AlterColumn<string>(
                name: "OngsId",
                table: "Incidents",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_OngsId",
                table: "Incidents",
                column: "OngsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Ongs_OngsId",
                table: "Incidents",
                column: "OngsId",
                principalTable: "Ongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Ongs_OngsId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_OngsId",
                table: "Incidents");

            migrationBuilder.AlterColumn<long>(
                name: "OngsId",
                table: "Incidents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OngId",
                table: "Incidents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_OngId",
                table: "Incidents",
                column: "OngId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Ongs_OngId",
                table: "Incidents",
                column: "OngId",
                principalTable: "Ongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
