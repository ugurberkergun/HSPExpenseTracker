using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSPExpenseTracker.DAL.Migrations
{
    public partial class _202310020948 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Category_CategoryId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "ModifiedDate", "Name", "RecordDate" },
                values: new object[,]
                {
                    { 2L, false, new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6060), "Sağlık Harcaması", new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6061) },
                    { 3L, false, new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6064), "Okul Masrafları", new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6064) },
                    { 4L, false, new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6066), "Eğlence", new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6066) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_CategoryId",
                table: "Transactions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_CategoryId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Category_CategoryId",
                table: "Transactions",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
