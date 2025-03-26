using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    /// <inheritdoc />
    public partial class wanttoopennew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasingGroups_Users_UserId",
                table: "PurchasingGroups");

            migrationBuilder.DropIndex(
                name: "IX_PurchasingGroups_UserId",
                table: "PurchasingGroups");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "PurchasingGroups");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PurchasingGroups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PurchasingGroups");

            migrationBuilder.CreateTable(
                name: "WantToOpens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantToOpens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WantToOpens_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WantToOpens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WantToOpens_CategoryId",
                table: "WantToOpens",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WantToOpens_UserId",
                table: "WantToOpens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WantToOpens");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "PurchasingGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PurchasingGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PurchasingGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingGroups_UserId",
                table: "PurchasingGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasingGroups_Users_UserId",
                table: "PurchasingGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
