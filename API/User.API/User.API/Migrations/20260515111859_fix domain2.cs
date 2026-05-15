using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.API.Migrations
{
    /// <inheritdoc />
    public partial class fixdomain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Permissions_permissionId",
                table: "UserPermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserPermissions_permissionId",
                table: "UserPermissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_permissionId",
                table: "UserPermissions",
                column: "permissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Permissions_permissionId",
                table: "UserPermissions",
                column: "permissionId",
                principalTable: "Permissions",
                principalColumn: "permissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
