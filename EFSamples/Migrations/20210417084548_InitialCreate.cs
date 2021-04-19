using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamples.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PagesCount = table.Column<int>(type: "int", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PagesCount", "Title", "VisitorId" },
                values: new object[,]
                {
                    { -2, "Фредрик Бакман", 600, "Тревожные люди", null },
                    { -4, "Эмили Сент-Джон Мандел", 1000, "Стеклянный отель", null }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -1, "Alex" },
                    { -2, "Oleg" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PagesCount", "Title", "VisitorId" },
                values: new object[,]
                {
                    { -1, "Элли Брош", 500, "Гипербола с половиной", -1 },
                    { -3, "Наринэ Абгарян", 400, "Симон", -1 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "BookId", "Price" },
                values: new object[,]
                {
                    { -1, -1, 100m },
                    { -2, -2, 200m },
                    { -3, -3, 300m },
                    { -4, -4, 400m },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_VisitorId",
                table: "Books",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_BookId",
                table: "Prices",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Name",
                table: "Visitors",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
