using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheBookCave.Migrations
{
    public partial class UpdateAddress_columnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ZipId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "CountryId",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZipId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);
        }
    }
}
