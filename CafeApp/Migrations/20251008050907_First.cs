using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeApp.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.CheckConstraint("CK_Employee_HireDate", "[HireDate] < CAST(GETUTCDATE() AS date)");
                    table.CheckConstraint("CK_Employee_Premium", "[Premium] > 0");
                    table.CheckConstraint("CK_Employee_Salary", "[Salary] > 0");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("CK_Product_Price_Positive", "[Price] > 0");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.CheckConstraint("CK_Order_CreatedAt", "[CreatedAt] < GETUTCDATE()");
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.CheckConstraint("CK_OrderItem_Quantity_Positive", "[Quantity] > 0");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.CheckConstraint("CK_Payment_Amount_Positive", "[Amount] > 0");
                    table.CheckConstraint("CK_Payment_Time", "[PaymentTime] < GETUTCDATE()");
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Coffee" },
                    { 2, "Desserts" },
                    { 3, "Main Dishes" },
                    { 4, "Drinks" },
                    { 5, "Snacks" },
                    { 6, "Salads" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "HireDate", "Name", "Premium", "Salary" },
                values: new object[,]
                {
                    { 1, new DateOnly(2021, 3, 15), "Alice Carter", 200m, 2200m },
                    { 2, new DateOnly(2022, 6, 5), "Brian Smith", 150m, 2100m },
                    { 3, new DateOnly(2020, 11, 2), "Catherine Jones", 300m, 2500m },
                    { 4, new DateOnly(2019, 8, 23), "Daniel Johnson", 350m, 2600m },
                    { 5, new DateOnly(2023, 2, 1), "Emma Brown", 120m, 2000m },
                    { 6, new DateOnly(2021, 9, 17), "Frank Wilson", 180m, 2300m },
                    { 7, new DateOnly(2022, 4, 12), "Grace Taylor", 140m, 2150m },
                    { 8, new DateOnly(2020, 7, 8), "Henry Miller", 400m, 2700m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Espresso", 3.00m },
                    { 2, 1, "Americano", 3.50m },
                    { 3, 1, "Cappuccino", 4.00m },
                    { 4, 1, "Latte", 4.50m },
                    { 5, 1, "Mocha", 4.80m },
                    { 6, 1, "Flat White", 4.20m },
                    { 7, 1, "Irish Coffee", 5.50m },
                    { 8, 1, "Macchiato", 3.80m },
                    { 9, 1, "Turkish Coffee", 3.20m },
                    { 10, 1, "Iced Latte", 4.60m },
                    { 11, 1, "Affogato", 5.00m },
                    { 12, 2, "Cheesecake", 5.00m },
                    { 13, 2, "Tiramisu", 5.50m },
                    { 14, 2, "Chocolate Cake", 4.80m },
                    { 15, 2, "Apple Pie", 4.00m },
                    { 16, 2, "Croissant", 2.50m },
                    { 17, 2, "Cinnamon Roll", 3.00m },
                    { 18, 2, "Brownie", 3.50m },
                    { 19, 2, "Muffin", 2.80m },
                    { 20, 2, "Eclair", 3.20m },
                    { 21, 2, "Fruit Tart", 4.70m },
                    { 22, 2, "Lemon Cake", 4.30m },
                    { 23, 2, "Macarons", 5.50m },
                    { 24, 3, "Beef Burger", 9.50m },
                    { 25, 3, "Chicken Sandwich", 8.00m },
                    { 26, 3, "Club Sandwich", 8.50m },
                    { 27, 3, "Grilled Salmon", 12.00m },
                    { 28, 3, "Spaghetti Carbonara", 10.50m },
                    { 29, 3, "Caesar Chicken", 9.00m },
                    { 30, 3, "Steak & Fries", 13.50m },
                    { 31, 3, "Fish & Chips", 10.00m },
                    { 32, 3, "Grilled Chicken", 9.20m },
                    { 33, 3, "Pasta Alfredo", 9.80m },
                    { 34, 3, "Beef Stroganoff", 11.00m },
                    { 35, 3, "Lasagna", 10.80m },
                    { 36, 4, "Cola", 2.00m },
                    { 37, 4, "Sprite", 2.00m },
                    { 38, 4, "Orange Juice", 3.00m },
                    { 39, 4, "Lemonade", 3.00m },
                    { 40, 4, "Mineral Water", 1.50m },
                    { 41, 4, "Iced Tea", 2.80m },
                    { 42, 4, "Milkshake", 4.00m },
                    { 43, 4, "Energy Drink", 3.50m },
                    { 44, 4, "Hot Chocolate", 3.80m },
                    { 45, 4, "Smoothie", 4.50m },
                    { 46, 4, "Cold Brew", 4.20m },
                    { 47, 5, "French Fries", 3.00m },
                    { 48, 5, "Onion Rings", 3.50m },
                    { 49, 5, "Mozzarella Sticks", 4.20m },
                    { 50, 5, "Chicken Nuggets", 4.50m },
                    { 51, 5, "Garlic Bread", 2.80m },
                    { 52, 5, "Nachos", 3.80m },
                    { 53, 5, "Popcorn", 2.50m },
                    { 54, 5, "Mini Sausages", 4.00m },
                    { 55, 5, "Cheese Balls", 3.70m },
                    { 56, 5, "Spring Rolls", 4.30m },
                    { 57, 6, "Caesar Salad", 6.50m },
                    { 58, 6, "Greek Salad", 6.00m },
                    { 59, 6, "Tuna Salad", 6.80m },
                    { 60, 6, "Chicken Salad", 6.50m },
                    { 61, 6, "Veggie Salad", 5.50m },
                    { 62, 6, "Pasta Salad", 6.20m },
                    { 63, 6, "Caprese Salad", 6.70m },
                    { 64, 6, "Quinoa Salad", 6.90m },
                    { 65, 6, "Couscous Salad", 6.80m },
                    { 66, 6, "Avocado Salad", 7.00m },
                    { 67, 6, "Asian Chicken Salad", 7.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
