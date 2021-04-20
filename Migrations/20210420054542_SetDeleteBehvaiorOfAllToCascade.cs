using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class SetDeleteBehvaiorOfAllToCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequest_User_RequestUserId",
                table: "BorrowRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetails_Book_RequestedBookId",
                table: "BorrowRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetails_BorrowRequest_BorrowRequestId",
                table: "BorrowRequestDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequest_User_RequestUserId",
                table: "BorrowRequest",
                column: "RequestUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetails_Book_RequestedBookId",
                table: "BorrowRequestDetails",
                column: "RequestedBookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetails_BorrowRequest_BorrowRequestId",
                table: "BorrowRequestDetails",
                column: "BorrowRequestId",
                principalTable: "BorrowRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequest_User_RequestUserId",
                table: "BorrowRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetails_Book_RequestedBookId",
                table: "BorrowRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequestDetails_BorrowRequest_BorrowRequestId",
                table: "BorrowRequestDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequest_User_RequestUserId",
                table: "BorrowRequest",
                column: "RequestUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetails_Book_RequestedBookId",
                table: "BorrowRequestDetails",
                column: "RequestedBookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequestDetails_BorrowRequest_BorrowRequestId",
                table: "BorrowRequestDetails",
                column: "BorrowRequestId",
                principalTable: "BorrowRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
