using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheBookCave.Migrations
{
    public partial class NrOfGradesInBookMigration_NrOfGradesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeEN",
                table: "OrderStatus",
                newName: "StatusEN");

            migrationBuilder.RenameColumn(
                name: "TypeIs",
                table: "HelpType",
                newName: "TypeIS");

            migrationBuilder.RenameColumn(
                name: "TypeEn",
                table: "HelpType",
                newName: "TypeEN");

            migrationBuilder.AddColumn<int>(
                name: "NrOfGrades",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfGrades",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "StatusEN",
                table: "OrderStatus",
                newName: "TypeEN");

            migrationBuilder.RenameColumn(
                name: "TypeIS",
                table: "HelpType",
                newName: "TypeIs");

            migrationBuilder.RenameColumn(
                name: "TypeEN",
                table: "HelpType",
                newName: "TypeEn");
        }
    }
}
