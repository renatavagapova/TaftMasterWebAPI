using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaftMasterWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReAddedFavoriteItemsProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItems_Rugs_RugId",
                table: "FavoriteItems");

            migrationBuilder.AlterColumn<int>(
                name: "RugId",
                table: "FavoriteItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "FavoriteItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdentifier",
                table: "FavoriteItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_CertificateId",
                table: "FavoriteItems",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItems_Certificates_CertificateId",
                table: "FavoriteItems",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItems_Rugs_RugId",
                table: "FavoriteItems",
                column: "RugId",
                principalTable: "Rugs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItems_Certificates_CertificateId",
                table: "FavoriteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItems_Rugs_RugId",
                table: "FavoriteItems");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteItems_CertificateId",
                table: "FavoriteItems");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "FavoriteItems");

            migrationBuilder.DropColumn(
                name: "UserIdentifier",
                table: "FavoriteItems");

            migrationBuilder.AlterColumn<int>(
                name: "RugId",
                table: "FavoriteItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItems_Rugs_RugId",
                table: "FavoriteItems",
                column: "RugId",
                principalTable: "Rugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
