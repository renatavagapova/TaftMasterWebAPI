using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaftMasterWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCartItemForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RugId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdentifier",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CertificateId",
                table: "CartItems",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Certificates_CertificateId",
                table: "CartItems",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Certificates_CertificateId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CertificateId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "UserIdentifier",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "RugId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
