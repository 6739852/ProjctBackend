using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    /// <inheritdoc />
    public partial class wanttoopenwithoutsupplier2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WantToOpens_Suppliers_SupplierId",
                table: "WantToOpens");

            migrationBuilder.DropIndex(
                name: "IX_WantToOpens_SupplierId",
                table: "WantToOpens");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "WantToOpens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "WantToOpens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WantToOpens_SupplierId",
                table: "WantToOpens",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_WantToOpens_Suppliers_SupplierId",
                table: "WantToOpens",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
