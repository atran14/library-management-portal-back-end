using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class InitialCreate_Take2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Unknown"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "None")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BorrowRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BorrowUntilDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestUserId = table.Column<int>(type: "int", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionByUserId = table.Column<int>(type: "int", nullable: true),
                    ActionStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowRequest_User_ActionByUserId",
                        column: x => x.ActionByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BorrowRequest_User_RequestUserId",
                        column: x => x.RequestUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BorrowRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowRequestId = table.Column<int>(type: "int", nullable: false),
                    RequestedBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowRequestDetails_Book_RequestedBookId",
                        column: x => x.RequestedBookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BorrowRequestDetails_BorrowRequest_BorrowRequestId",
                        column: x => x.BorrowRequestId,
                        principalTable: "BorrowRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action and Adventure" },
                    { 2, "Classics" },
                    { 3, "Comic Book/Graphic Novel" },
                    { 4, "Detective and Mystery" },
                    { 5, "Fantasy" },
                    { 6, "Historical Fiction" },
                    { 7, "Horror" },
                    { 8, "Literary Fiction" },
                    { 9, "Science Fiction" },
                    { 10, "Short Stories" },
                    { 11, "Suspense and Thrillers" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DOB", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "admin", "12345", "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DOB", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 2, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "McFarland", "bob97", 1, "bob97" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Authors", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Yann Martel", 1, "Generic description", "Life of Pi" },
                    { 30, "Junot Diaz", 11, "Generic description", "This Is How You Lose Her" },
                    { 29, "George Orwell", 10, "Generic description", "1984" },
                    { 28, "Suzanne Collins", 10, "Generic description", "The Hunger Games Trilogy" },
                    { 27, "Margaret Atwood", 10, "Generic description", "The Testaments" },
                    { 26, "J. R. Ward", 9, "Generic description", "The Savior" },
                    { 25, "Jasmine Guillory", 9, "Generic description", "Royal Holiday" },
                    { 24, "Sarah MacLean", 9, "Generic description", "Brazen and the Beast" },
                    { 23, "Ann Patchett", 8, "Generic description", "The Dutch House" },
                    { 22, "Elizabeth Strout", 8, "Generic description", "Olive, Again" },
                    { 21, "Delia Owens", 8, "Generic description", "Where the Crawdads Sing" },
                    { 20, "Josh Malerman", 7, "Generic description", "Bird Box" },
                    { 19, "Shirley Jackson", 7, "Generic description", "The Haunting of Hill House" },
                    { 18, "Stephen King", 7, "Generic description", "Carrie" },
                    { 17, "Arthur Golden", 6, "Generic description", "Memoirs of a Geisha" },
                    { 16, "Gabriel Garcia Marquez", 6, "Generic description", "One Hundred Years of Solitude" },
                    { 15, "Kathryn Stockett", 6, "Generic description", "The Help" },
                    { 14, "Leigh Bardugo", 5, "Generic description", "Ninth House" },
                    { 13, "Madeline Miller", 5, "Generic description", "Circe" },
                    { 12, "Ta-Nehisi Coates", 5, "Generic description", "The Water Dancer" },
                    { 11, "Agatha Christie", 4, "Generic description", "And Then There Were None" },
                    { 10, "Sir Arthur Conan Doyle", 4, "Generic description", "The Adventures of Sherlock Holmes" },
                    { 9, "Michael Connelly", 4, "Generic description", "The Night Fire" },
                    { 8, "Charlie Mackery", 3, "Generic description", "The Boy, the Mole, the Fox and the Horse" },
                    { 7, "Alan Moore, Dave Gibbons", 3, "Generic description", "Watchmen" },
                    { 6, "Toni Morrison", 2, "Generic description", "Beloved" },
                    { 5, "Louisa May Alcott", 2, "Generic description", "Little Women" },
                    { 4, "Harper Lee", 2, "Generic description", "To Kill a Mockingbird" },
                    { 3, "Jack London", 1, "Generic description", "The Call of the Wild" },
                    { 2, "Alexandre Dumas", 1, "Generic description", "The Three Musketeers" },
                    { 31, "Lauren Groff", 11, "Generic description", "Florida" },
                    { 32, "N. K. Jemisin", 11, "Generic description", "How Long 'Til Black Future Month?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequest_ActionByUserId",
                table: "BorrowRequest",
                column: "ActionByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequest_RequestUserId",
                table: "BorrowRequest",
                column: "RequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequestDetails_BorrowRequestId",
                table: "BorrowRequestDetails",
                column: "BorrowRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequestDetails_RequestedBookId",
                table: "BorrowRequestDetails",
                column: "RequestedBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowRequestDetails");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BorrowRequest");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
