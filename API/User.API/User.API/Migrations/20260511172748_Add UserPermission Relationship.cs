using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPermissionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    permissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isReadable = table.Column<bool>(type: "bit", nullable: false),
                    isWritable = table.Column<bool>(type: "bit", nullable: false),
                    isDeletable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => new { x.userId, x.permissionId });
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_permissionId",
                        column: x => x.permissionId,
                        principalTable: "Permissions",
                        principalColumn: "permissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_permissionId",
                table: "UserPermissions",
                column: "permissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissions");
        }
    }
}
