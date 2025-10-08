using System.Collections.ObjectModel;
using System.Windows.Input;
using CafeApp.Commands;
using CafeApp.Data;
using CafeApp.Models;
using CafeApp.ViewModels.Abstractions;

namespace CafeApp.ViewModels;

public class MainViewModel : BaseViewModel
{
    private AppDbContext _dbContext;
    private Category? _selectedCategory;
    private Product? _selectedProduct;
    private ObservableCollection<Product> _products = new();
    private int _productAmount;
    private ObservableCollection<int>  _vacantTables = new();
    private int _selectedVacantTable;
    public ObservableCollection<Category> Categories { get; set; } = new();

    public Category? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            SetField<Category>(ref _selectedCategory, value);
            LoadProducts(value.Id);
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
        set
        {
            SetField<Product>(ref _selectedProduct, value); 
            ProductAmount = _selectedProduct == null ? 0 : 1;
        }
    }

    public int ProductAmount
    {
        get => _productAmount;
        set
        {
            
            SetField(ref _productAmount, value);  
        } 
    }

    public List<int> Tables { get; set; } = [13, 27, 81, 69, 47, 51, 39, 78, 90, 65, 43, 11, 19, 21, 50, 54, 89, 66, 35, 72];

    public ObservableCollection<int> VacantTables
    {
        get => _vacantTables;
        set => _vacantTables = value;
    }

    public int SelectedVacantTable
    {
        get => _selectedVacantTable;
        set => _selectedVacantTable = value;
    }

    public ICommand IncrementAmountCommand { get; set; }
    public ICommand DecrementAmountCommand { get; set; }
    public MainViewModel(AppDbContext dbContext)
    {
        IncrementAmountCommand = new RelayCommand(_ => ProductAmount++, _ => SelectedProduct != null );
        DecrementAmountCommand = new RelayCommand(_ => ProductAmount--, _ => SelectedProduct != null && ProductAmount > 1 );
        _dbContext = dbContext;
        
        LoadCategories();
     
        SelectedCategory = Categories[0];
    }

    private void LoadProducts(int categoryId)
    {
        var products = _dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        
        Products.Clear();

        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    private void LoadCategories()
    {
        var categories = _dbContext.Categories.ToList();
        
        Categories.Clear();
        
        foreach (var category in categories)
        {
            Categories.Add(category);
        }
    }

}


