using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.API.Migrations
{
    /// <inheritdoc />
    public partial class FixPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserruserId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserruserId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UserruserId",
                table: "Permissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserruserId",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "permissionId",
                keyValue: "1",
                column: "UserruserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "permissionId",
                keyValue: "2",
                column: "UserruserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "permissionId",
                keyValue: "3",
                column: "UserruserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserruserId",
                table: "Permissions",
                column: "UserruserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserruserId",
                table: "Permissions",
                column: "UserruserId",
                principalTable: "Users",
                principalColumn: "userId");
        }
    }
}
