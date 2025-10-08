using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeApp.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                    table.CheckConstraint("CK_Table_Number_Positive", "[Number] > 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TableId",
                table: "Customers",
                column: "TableId",
                unique: true,
                filter: "[TableId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Table_TableId",
                table: "Customers",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Table_TableId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TableId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
