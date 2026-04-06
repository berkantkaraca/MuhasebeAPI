using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuhasebeAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E89E949-4A5A-4E4A-9B67-53E1ACB3C8A1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B7B067AA-3D3A-4A16-B4EA-0B6C5E8EC6F2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B7B067AA-3D3A-4A16-B4EA-0DKFJSDKFLSKF");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B7B067AA-3D3A-4A16-B4EA-KSFJKLDSJFLDKD");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRoleCreatedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainRoles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainRoleAndRoleRelationships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MainRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainRoleAndRoleRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainRoleAndRoleRelationships_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainRoleAndRoleRelationships_MainRoles_MainRoleId",
                        column: x => x.MainRoleId,
                        principalTable: "MainRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainRoleAndUserRelationships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MainRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainRoleAndUserRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainRoleAndUserRelationships_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainRoleAndUserRelationships_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainRoleAndUserRelationships_MainRoles_MainRoleId",
                        column: x => x.MainRoleId,
                        principalTable: "MainRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndRoleRelationships_MainRoleId",
                table: "MainRoleAndRoleRelationships",
                column: "MainRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndRoleRelationships_RoleId",
                table: "MainRoleAndRoleRelationships",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndUserRelationships_CompanyId",
                table: "MainRoleAndUserRelationships",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndUserRelationships_MainRoleId",
                table: "MainRoleAndUserRelationships",
                column: "MainRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndUserRelationships_UserId",
                table: "MainRoleAndUserRelationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoles_CompanyId",
                table: "MainRoles",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainRoleAndRoleRelationships");

            migrationBuilder.DropTable(
                name: "MainRoleAndUserRelationships");

            migrationBuilder.DropTable(
                name: "MainRoles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Code", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9E89E949-4A5A-4E4A-9B67-53E1ACB3C8A1", "UCAF.Create", "D3A5D5A2-A0E8-4A69-BD5B-6F26E0E8B611", "Hesap Planı Kayıt Ekleme", "HESAP PLANI KAYIT EKLEME" },
                    { "B7B067AA-3D3A-4A16-B4EA-0B6C5E8EC6F2", "UCAF.Update", "8E944A99-6F47-4D4D-9E9F-0AA5F08C3D9E", "Hesap Planı Kayıt Güncelleme", "HESAP PLANI KAYIT GUNCELLEME" },
                    { "B7B067AA-3D3A-4A16-B4EA-0DKFJSDKFLSKF", "UCAF.Read", "8E944A99-6F47-4D4D-9E9F-0AA5F08C3D9E", "Hesap Planı Kayıt Görüntüleme", "HESAP PLANI KAYIT GORUNTULEME" },
                    { "B7B067AA-3D3A-4A16-B4EA-KSFJKLDSJFLDKD", "UCAF.Balance", "8E944A99-6F47-4D4D-9E9F-0AA5F08C3D9E", "Hesap Planı Bakiye Görüntüleme", "HESAP PLANI BAKIYE GORUNTULEME" }
                });
        }
    }
}
