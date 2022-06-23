using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocAPI.Migrations
{
    public partial class AddWebConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitSha",
                table: "DocsCatalogs",
                type: "TEXT",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GitUrl",
                table: "DocsCatalogs",
                type: "TEXT",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "DocsCatalogs",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GitSha",
                table: "Docs",
                type: "TEXT",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GitUrl",
                table: "Docs",
                type: "TEXT",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Docs",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Docs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WebConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WebSiteName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    GithubUser = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    GithubPAT = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    RepositoryId = table.Column<long>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebConfigs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebConfigs");

            migrationBuilder.DropColumn(
                name: "GitSha",
                table: "DocsCatalogs");

            migrationBuilder.DropColumn(
                name: "GitUrl",
                table: "DocsCatalogs");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "DocsCatalogs");

            migrationBuilder.DropColumn(
                name: "GitSha",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "GitUrl",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Docs");
        }
    }
}
