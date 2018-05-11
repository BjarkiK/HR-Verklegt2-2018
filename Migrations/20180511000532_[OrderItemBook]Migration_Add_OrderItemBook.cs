using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheBookCave.Migrations
{
    public partial class OrderItemBookMigration_Add_OrderItemBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItemBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    DetailsEN = table.Column<string>(nullable: true),
                    DetailsIS = table.Column<string>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Grade = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NrOfGrades = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false),
                    Pages = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemBook", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemBook");
        }
    }
}
