using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocAPI.Migrations;

public partial class Init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "DocsCatalogs",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                ParentId = table.Column<Guid>(type: "TEXT", nullable: true),
                Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                Sort = table.Column<int>(type: "INTEGER", nullable: false),
                Status = table.Column<int>(type: "INTEGER", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DocsCatalogs", x => x.Id);
                table.ForeignKey(
                    name: "FK_DocsCatalogs_DocsCatalogs_ParentId",
                    column: x => x.ParentId,
                    principalTable: "DocsCatalogs",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Docs",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                Content = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: true),
                DocsCatalogId = table.Column<Guid>(type: "TEXT", nullable: false),
                Status = table.Column<int>(type: "INTEGER", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Docs", x => x.Id);
                table.ForeignKey(
                    name: "FK_Docs_DocsCatalogs_DocsCatalogId",
                    column: x => x.DocsCatalogId,
                    principalTable: "DocsCatalogs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Docs_DocsCatalogId",
            table: "Docs",
            column: "DocsCatalogId");

        migrationBuilder.CreateIndex(
            name: "IX_DocsCatalogs_ParentId",
            table: "DocsCatalogs",
            column: "ParentId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Docs");

        migrationBuilder.DropTable(
            name: "DocsCatalogs");
    }
}
