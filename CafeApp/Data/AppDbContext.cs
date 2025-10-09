using CafeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Table> Tables { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "Aga Mammadov" },
            new Customer { Id = 2, Name = "Aynur Huseynova" },
            new Customer { Id = 3, Name = "Rashad Aliyev" },
            new Customer { Id = 4, Name = "Nigar Gasimova" },
            new Customer { Id = 5, Name = "Elvin Azimov" },
            new Customer { Id = 6, Name = "Sevil Mammadli" },
            new Customer { Id = 7, Name = "Kamran Ibrahimov" },
            new Customer { Id = 8, Name = "Farid Ismayilov" },
            new Customer { Id = 9, Name = "Lala Taghizade" },
            new Customer { Id = 10, Name = "Tural Safarov" }
        );
        
          modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Coffee" },
            new Category { Id = 2, Name = "Desserts" },
            new Category { Id = 3, Name = "Main Dishes" },
            new Category { Id = 4, Name = "Drinks" },
            new Category { Id = 5, Name = "Snacks" },
            new Category { Id = 6, Name = "Salads" }
        );
        
        modelBuilder.Entity<Product>().HasData(
    
        new Product { Id = 1, Name = "Espresso", Price = 3.00m, CategoryId = 1 },
        new Product { Id = 2, Name = "Americano", Price = 3.50m, CategoryId = 1 },
        new Product { Id = 3, Name = "Cappuccino", Price = 4.00m, CategoryId = 1 },
        new Product { Id = 4, Name = "Latte", Price = 4.50m, CategoryId = 1 },
        new Product { Id = 5, Name = "Mocha", Price = 4.80m, CategoryId = 1 },
        new Product { Id = 6, Name = "Flat White", Price = 4.20m, CategoryId = 1 },
        new Product { Id = 7, Name = "Irish Coffee", Price = 5.50m, CategoryId = 1 },
        new Product { Id = 8, Name = "Macchiato", Price = 3.80m, CategoryId = 1 },
        new Product { Id = 9, Name = "Turkish Coffee", Price = 3.20m, CategoryId = 1 },
        new Product { Id = 10, Name = "Iced Latte", Price = 4.60m, CategoryId = 1 },
        new Product { Id = 11, Name = "Affogato", Price = 5.00m, CategoryId = 1 },
        
        new Product { Id = 12, Name = "Cheesecake", Price = 5.00m, CategoryId = 2 },
        new Product { Id = 13, Name = "Tiramisu", Price = 5.50m, CategoryId = 2 },
        new Product { Id = 14, Name = "Chocolate Cake", Price = 4.80m, CategoryId = 2 },
        new Product { Id = 15, Name = "Apple Pie", Price = 4.00m, CategoryId = 2 },
        new Product { Id = 16, Name = "Croissant", Price = 2.50m, CategoryId = 2 },
        new Product { Id = 17, Name = "Cinnamon Roll", Price = 3.00m, CategoryId = 2 },
        new Product { Id = 18, Name = "Brownie", Price = 3.50m, CategoryId = 2 },
        new Product { Id = 19, Name = "Muffin", Price = 2.80m, CategoryId = 2 },
        new Product { Id = 20, Name = "Eclair", Price = 3.20m, CategoryId = 2 },
        new Product { Id = 21, Name = "Fruit Tart", Price = 4.70m, CategoryId = 2 },
        new Product { Id = 22, Name = "Lemon Cake", Price = 4.30m, CategoryId = 2 },
        new Product { Id = 23, Name = "Macarons", Price = 5.50m, CategoryId = 2 },
        
        new Product { Id = 24, Name = "Beef Burger", Price = 9.50m, CategoryId = 3 },
        new Product { Id = 25, Name = "Chicken Sandwich", Price = 8.00m, CategoryId = 3 },
        new Product { Id = 26, Name = "Club Sandwich", Price = 8.50m, CategoryId = 3 },
        new Product { Id = 27, Name = "Grilled Salmon", Price = 12.00m, CategoryId = 3 },
        new Product { Id = 28, Name = "Spaghetti Carbonara", Price = 10.50m, CategoryId = 3 },
        new Product { Id = 29, Name = "Caesar Chicken", Price = 9.00m, CategoryId = 3 },
        new Product { Id = 30, Name = "Steak & Fries", Price = 13.50m, CategoryId = 3 },
        new Product { Id = 31, Name = "Fish & Chips", Price = 10.00m, CategoryId = 3 },
        new Product { Id = 32, Name = "Grilled Chicken", Price = 9.20m, CategoryId = 3 },
        new Product { Id = 33, Name = "Pasta Alfredo", Price = 9.80m, CategoryId = 3 },
        new Product { Id = 34, Name = "Beef Stroganoff", Price = 11.00m, CategoryId = 3 },
        new Product { Id = 35, Name = "Lasagna", Price = 10.80m, CategoryId = 3 },
        
        new Product { Id = 36, Name = "Cola", Price = 2.00m, CategoryId = 4 },
        new Product { Id = 37, Name = "Sprite", Price = 2.00m, CategoryId = 4 },
        new Product { Id = 38, Name = "Orange Juice", Price = 3.00m, CategoryId = 4 },
        new Product { Id = 39, Name = "Lemonade", Price = 3.00m, CategoryId = 4 },
        new Product { Id = 40, Name = "Mineral Water", Price = 1.50m, CategoryId = 4 },
        new Product { Id = 41, Name = "Iced Tea", Price = 2.80m, CategoryId = 4 },
        new Product { Id = 42, Name = "Milkshake", Price = 4.00m, CategoryId = 4 },
        new Product { Id = 43, Name = "Energy Drink", Price = 3.50m, CategoryId = 4 },
        new Product { Id = 44, Name = "Hot Chocolate", Price = 3.80m, CategoryId = 4 },
        new Product { Id = 45, Name = "Smoothie", Price = 4.50m, CategoryId = 4 },
        new Product { Id = 46, Name = "Cold Brew", Price = 4.20m, CategoryId = 4 },
        
        new Product { Id = 47, Name = "French Fries", Price = 3.00m, CategoryId = 5 },
        new Product { Id = 48, Name = "Onion Rings", Price = 3.50m, CategoryId = 5 },
        new Product { Id = 49, Name = "Mozzarella Sticks", Price = 4.20m, CategoryId = 5 },
        new Product { Id = 50, Name = "Chicken Nuggets", Price = 4.50m, CategoryId = 5 },
        new Product { Id = 51, Name = "Garlic Bread", Price = 2.80m, CategoryId = 5 },
        new Product { Id = 52, Name = "Nachos", Price = 3.80m, CategoryId = 5 },
        new Product { Id = 53, Name = "Popcorn", Price = 2.50m, CategoryId = 5 },
        new Product { Id = 54, Name = "Mini Sausages", Price = 4.00m, CategoryId = 5 },
        new Product { Id = 55, Name = "Cheese Balls", Price = 3.70m, CategoryId = 5 },
        new Product { Id = 56, Name = "Spring Rolls", Price = 4.30m, CategoryId = 5 },
        
        new Product { Id = 57, Name = "Caesar Salad", Price = 6.50m, CategoryId = 6 },
        new Product { Id = 58, Name = "Greek Salad", Price = 6.00m, CategoryId = 6 },
        new Product { Id = 59, Name = "Tuna Salad", Price = 6.80m, CategoryId = 6 },
        new Product { Id = 60, Name = "Chicken Salad", Price = 6.50m, CategoryId = 6 },
        new Product { Id = 61, Name = "Veggie Salad", Price = 5.50m, CategoryId = 6 },
        new Product { Id = 62, Name = "Pasta Salad", Price = 6.20m, CategoryId = 6 },
        new Product { Id = 63, Name = "Caprese Salad", Price = 6.70m, CategoryId = 6 },
        new Product { Id = 64, Name = "Quinoa Salad", Price = 6.90m, CategoryId = 6 },
        new Product { Id = 65, Name = "Couscous Salad", Price = 6.80m, CategoryId = 6 },
        new Product { Id = 66, Name = "Avocado Salad", Price = 7.00m, CategoryId = 6 },
        new Product { Id = 67, Name = "Asian Chicken Salad", Price = 7.50m, CategoryId = 6 }
    );
        modelBuilder.Entity<Employee>().HasData(
        new Employee
        {
            Id = 1,
            Name = "Alice Carter",
            HireDate = new DateOnly(2021, 3, 15),
            Salary = 2200,
            Premium = 200
        },
        new Employee
        {
            Id = 2,
            Name = "Brian Smith",
            HireDate = new DateOnly(2022, 6, 5),
            Salary = 2100,
            Premium = 150
        },
        new Employee
        {
            Id = 3,
            Name = "Catherine Jones",
            HireDate = new DateOnly(2020, 11, 2),
            Salary = 2500,
            Premium = 300
        },
        new Employee
        {
            Id = 4,
            Name = "Daniel Johnson",
            HireDate = new DateOnly(2019, 8, 23),
            Salary = 2600,
            Premium = 350
        },
        new Employee
        {
            Id = 5,
            Name = "Emma Brown",
            HireDate = new DateOnly(2023, 2, 1),
            Salary = 2000,
            Premium = 120
        },
        new Employee
        {
            Id = 6,
            Name = "Frank Wilson",
            HireDate = new DateOnly(2021, 9, 17),
            Salary = 2300,
            Premium = 180
        },
        new Employee
        {
            Id = 7,
            Name = "Grace Taylor",
            HireDate = new DateOnly(2022, 4, 12),
            Salary = 2150,
            Premium = 140
        },
        new Employee
        {
            Id = 8,
            Name = "Henry Miller",
            HireDate = new DateOnly(2020, 7, 8),
            Salary = 2700,
            Premium = 400
        }
        );
        
        modelBuilder.Entity<Table>().HasData(
            new Table { Id = 1, Number = 10 },
            new Table { Id = 2, Number = 12 },
            new Table { Id = 3, Number = 15 },
            new Table { Id = 4, Number = 18 },
            new Table { Id = 5, Number = 22 },
            new Table { Id = 6, Number = 35 },
            new Table { Id = 7, Number = 41 },
            new Table { Id = 8, Number = 56 },
            new Table { Id = 9, Number = 73 },
            new Table { Id = 10, Number = 88 }
        );
    }
}