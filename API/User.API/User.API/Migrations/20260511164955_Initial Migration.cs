using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_userId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_userId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Permissions");

            migrationBuilder.AlterColumn<Guid>(
                name: "roleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "userId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "roleId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "permissionId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserruserId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "roleId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "roleId",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "permissionId",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_userId",
                table: "Permissions",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_userId",
                table: "Permissions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");
        }
    }
}
