using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Context.Migrations
{
    public partial class AddArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Accounts_AccountId",
                table: "Catalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Catalogs_ParentId",
                table: "Catalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Libraries_Catalogs_CatalogId",
                table: "Libraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs");

            migrationBuilder.RenameTable(
                name: "Catalogs",
                newName: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_Type",
                table: "Catalog",
                newName: "IX_Catalog_Type");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_Sort",
                table: "Catalog",
                newName: "IX_Catalog_Sort");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_ParentId",
                table: "Catalog",
                newName: "IX_Catalog_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_Name",
                table: "Catalog",
                newName: "IX_Catalog_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_Level",
                table: "Catalog",
                newName: "IX_Catalog_Level");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogs_AccountId",
                table: "Catalog",
                newName: "IX_Catalog_AccountId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Catalog",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ArticleExtends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleExtends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Summary = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AuthorName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Tags = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ArticleType = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtendId = table.Column<Guid>(type: "uuid", nullable: true),
                    CatalogId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleExtends_ExtendId",
                        column: x => x.ExtendId,
                        principalTable: "ArticleExtends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Catalog_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: true),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AccountId",
                table: "Articles",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleType",
                table: "Articles",
                column: "ArticleType");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CatalogId",
                table: "Articles",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedTime",
                table: "Articles",
                column: "CreatedTime");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ExtendId",
                table: "Articles",
                column: "ExtendId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Title",
                table: "Articles",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AccountId",
                table: "Comments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedTime",
                table: "Comments",
                column: "CreatedTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Accounts_AccountId",
                table: "Catalog",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Catalog_ParentId",
                table: "Catalog",
                column: "ParentId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libraries_Catalog_CatalogId",
                table: "Libraries",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Accounts_AccountId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Catalog_ParentId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Libraries_Catalog_CatalogId",
                table: "Libraries");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleExtends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Catalog");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "Catalogs");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Type",
                table: "Catalogs",
                newName: "IX_Catalogs_Type");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Sort",
                table: "Catalogs",
                newName: "IX_Catalogs_Sort");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_ParentId",
                table: "Catalogs",
                newName: "IX_Catalogs_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Name",
                table: "Catalogs",
                newName: "IX_Catalogs_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Level",
                table: "Catalogs",
                newName: "IX_Catalogs_Level");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_AccountId",
                table: "Catalogs",
                newName: "IX_Catalogs_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Accounts_AccountId",
                table: "Catalogs",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Catalogs_ParentId",
                table: "Catalogs",
                column: "ParentId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libraries_Catalogs_CatalogId",
                table: "Libraries",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
