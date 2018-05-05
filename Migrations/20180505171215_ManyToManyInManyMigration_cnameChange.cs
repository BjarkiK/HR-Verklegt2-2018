using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheBookCave.Migrations
{
    public partial class ManyToManyInManyMigration_cnameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "published",
                table: "Subscriptions",
                newName: "Published");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Orders",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Helps",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Books",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "published",
                table: "Books",
                newName: "Published");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Books",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "pages",
                table: "Books",
                newName: "Pages");

            migrationBuilder.RenameColumn(
                name: "grade",
                table: "Books",
                newName: "Grade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Published",
                table: "Subscriptions",
                newName: "published");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Orders",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Helps",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Books",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Published",
                table: "Books",
                newName: "published");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Pages",
                table: "Books",
                newName: "pages");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Books",
                newName: "grade");
        }
    }
}
