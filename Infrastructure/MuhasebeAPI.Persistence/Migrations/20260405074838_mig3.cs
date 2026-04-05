using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhasebeAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAndCompanyRelationships_AspNetUsers_AppUserId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndCompanyRelationships_Companies_CompanyId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "NameLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpires",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndCompanyRelationships_AspNetUsers_AppUserId",
                table: "UserAndCompanyRelationships",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndCompanyRelationships_Companies_CompanyId",
                table: "UserAndCompanyRelationships",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAndCompanyRelationships_AspNetUsers_AppUserId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndCompanyRelationships_Companies_CompanyId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.DropColumn(
                name: "NameLastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpires",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndCompanyRelationships_AspNetUsers_AppUserId",
                table: "UserAndCompanyRelationships",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndCompanyRelationships_Companies_CompanyId",
                table: "UserAndCompanyRelationships",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
