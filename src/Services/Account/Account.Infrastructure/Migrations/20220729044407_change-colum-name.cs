using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.Infrastructure.Migrations
{
    public partial class changecolumname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "AccountActivity",
                newName: "TransactionAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionAmount",
                table: "AccountActivity",
                newName: "Amount");
        }
    }
}
