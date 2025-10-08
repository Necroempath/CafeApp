using System.Collections.ObjectModel;
using CafeApp.Models;
using CafeApp.ViewModels.Abstractions;

namespace CafeApp.ViewModels;

public class MainViewModel : BaseViewModel
{
    private Category? _selectedCategory;
    private Product? _selectedProduct;
    private ObservableCollection<Product> _products = new();
    private int _productAmount;
    public ObservableCollection<Category> Categories { get; set; } = new();

    public Category? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            SetField<Category>(ref _selectedCategory, value);
            Products.Clear();
            foreach (var product in _selectedCategory.Products)
            {
                Products.Add(product);
            }
        }
    }

    public ObservableCollection<Product> Products
    {
        get => _products;
        set => SetField(ref _products, value);
    }

    public Product? SelectedProduct
    {
        get => _selectedProduct;
        set => SetField<Product>(ref _selectedProduct, value);
    }

    public int ProductAmount
    {
        get => _productAmount;
        set =>  SetField(ref _productAmount, value);
    }

    public MainViewModel()
    {
        LoadCategories();
    }

    void LoadCategories()
    {
        SetCategories();
        SelectedCategory = Categories[0];
    }
    void SetCategories()
    {
        Categories.Add(new Category
        {
            Name = "Drinks",
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Coffee", Price = 3 },
                new Product { Name = "Tea", Price = 2.5m },
                new Product { Name = "Juice", Price = 4 },
                new Product { Name = "Soda", Price = 2 },
                new Product { Name = "Water", Price = 1 },
                new Product { Name = "Smoothie", Price = 5 },
            }
        });

        Categories.Add(new Category
        {
            Name = "Desserts",
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Cake", Price = 4 },
                new Product { Name = "Ice Cream", Price = 3 },
                new Product { Name = "Pie", Price = 3.5m },
                new Product { Name = "Brownie", Price = 3 },
                new Product { Name = "Muffin", Price = 2.5m },
                new Product { Name = "Pudding", Price = 3 },
            }
        });

        Categories.Add(new Category
        {
            Name = "Main Dishes",
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Pizza", Price = 8 },
                new Product { Name = "Burger", Price = 6 },
                new Product { Name = "Pasta", Price = 7 },
                new Product { Name = "Salad", Price = 5 },
                new Product { Name = "Steak", Price = 12 },
                new Product { Name = "Sandwich", Price = 5.5m },
            }
        });

        Categories.Add(new Category
        {
            Name = "Snacks",
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Fries", Price = 2.5m },
                new Product { Name = "Nachos", Price = 3 },
                new Product { Name = "Onion Rings", Price = 3 },
                new Product { Name = "Popcorn", Price = 1.5m },
                new Product { Name = "Nuggets", Price = 4 },
                new Product { Name = "Pretzel", Price = 2 },
            }
        });
    }

}


