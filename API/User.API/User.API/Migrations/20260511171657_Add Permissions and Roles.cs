using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace User.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionsandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    permissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    permissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserruserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.permissionId);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_UserruserId",
                        column: x => x.UserruserId,
                        principalTable: "Users",
                        principalColumn: "userId");
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "permissionId", "UserruserId", "permissionName" },
                values: new object[,]
                {
                    { "1", null, "Manage Users" },
                    { "2", null, "Manage Reports" },
                    { "3", null, "Manage Invoices" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "roleId", "roleName" },
                values: new object[,]
                {
                    { "1", "HR Admin" },
                    { "2", "Super Admin" },
                    { "3", "Admin" },
                    { "4", "Employee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserruserId",
                table: "Permissions",
                column: "UserruserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
