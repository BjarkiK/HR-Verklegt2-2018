using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheBookCave.Migrations
{
    public partial class changeDescriptionTypeFromIntToStringInGenreAndHelpMigration1of2_cnameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                            migrationBuilder.DropColumn(
                name: "GenreIs",
                table: "Genre");

                migrationBuilder.DropColumn(
                name: "GenreEn",
                table: "Genre");

                migrationBuilder.DropColumn(
                name: "AnswerIS",
                table: "Helps");

                migrationBuilder.DropColumn(
                name: "AnswerEN",
                table: "Helps");

                migrationBuilder.AddColumn<string>(
                name: "GenreIS",
                table: "Genre");

                migrationBuilder.AddColumn<string>(
                name: "GenreEN",
                table: "Genre");

                migrationBuilder.AddColumn<string>(
                name: "AnswerEN",
                table: "Helps");

                migrationBuilder.AddColumn<string>(
                name: "AnswerIS",
                table: "Helps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreIS",
                table: "Genre",
                newName: "GenreIs");

            migrationBuilder.RenameColumn(
                name: "GenreEN",
                table: "Genre",
                newName: "GenreEn");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerIS",
                table: "Helps",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerEN",
                table: "Helps",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreIs",
                table: "Genre",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreEn",
                table: "Genre",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
