using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class BorrowRequest_RemovedUnneededProperty_BorrowRequestDetailsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowRequestDetailsId",
                table: "BorrowRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowRequestDetailsId",
                table: "BorrowRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
