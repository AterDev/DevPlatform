using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Entity.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountExtends",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    RealName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    NickName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Birthday = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Province = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    County = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Street = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    AddressDetail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    WXOpenId = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    WXAvatar = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    WXUnionId = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountExtends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Password = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    HashSalt = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    LastLoginTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
                    PhoneConfirm = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmailConfirm = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Avatar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ExtendId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountExtends_ExtendId",
                        column: x => x.ExtendId,
                        principalTable: "AccountExtends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountRole",
                columns: table => new
                {
                    AccountsId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    RolesId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => new { x.AccountsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_AccountRole_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Sort = table.Column<short>(type: "smallint", nullable: false),
                    Level = table.Column<short>(type: "smallint", nullable: false),
                    ParentId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    AccountId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalogs_Catalogs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libs",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Namespace = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Language = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IsValid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    CatalogId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libs_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Libs_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true),
                    LibId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_Libs_LibId",
                        column: x => x.LibId,
                        principalTable: "Libs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountExtends_City",
                table: "AccountExtends",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_AccountExtends_Country",
                table: "AccountExtends",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_AccountExtends_Province",
                table: "AccountExtends",
                column: "Province");

            migrationBuilder.CreateIndex(
                name: "IX_AccountExtends_RealName",
                table: "AccountExtends",
                column: "RealName");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_RolesId",
                table: "AccountRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreatedTime",
                table: "Accounts",
                column: "CreatedTime");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmailConfirm",
                table: "Accounts",
                column: "EmailConfirm");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ExtendId",
                table: "Accounts",
                column: "ExtendId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IsDeleted",
                table: "Accounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Phone",
                table: "Accounts",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PhoneConfirm",
                table: "Accounts",
                column: "PhoneConfirm");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_AccountId",
                table: "Catalogs",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Level",
                table: "Catalogs",
                column: "Level");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Name",
                table: "Catalogs",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_ParentId",
                table: "Catalogs",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Sort",
                table: "Catalogs",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Type",
                table: "Catalogs",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_CreatedTime",
                table: "Entities",
                column: "CreatedTime");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_LibId",
                table: "Entities",
                column: "LibId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_Name",
                table: "Entities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_Status",
                table: "Entities",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Libs_CatalogId",
                table: "Libs",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Libs_CreatedTime",
                table: "Libs",
                column: "CreatedTime");

            migrationBuilder.CreateIndex(
                name: "IX_Libs_IsValid",
                table: "Libs",
                column: "IsValid");

            migrationBuilder.CreateIndex(
                name: "IX_Libs_Language",
                table: "Libs",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_Libs_Namespace",
                table: "Libs",
                column: "Namespace");

            migrationBuilder.CreateIndex(
                name: "IX_Libs_UserId",
                table: "Libs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Status",
                table: "Roles",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRole");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Libs");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountExtends");
        }
    }
}
