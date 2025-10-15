using System.Collections.ObjectModel;
using System.Windows.Input;
using CafeApp.Commands;
using CafeApp.Data;
using CafeApp.Models;
using CafeApp.ViewModels.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.ViewModels;

public class MainViewModel : BaseViewModel
{
    private AppDbContext _dbContext;
    private Category? _selectedCategory;
    private Product? _selectedProduct;
    private int _productAmount;
    private decimal _totalPrice;
    private Table _selectedTable;
    private OrderView? _selectedUncompletedOrder;
    private OrderView? _selectedCompletedOrder;
    private OrderItem? _selectedOrderItem;
    private List<Employee> _employees = new();
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
    public ObservableCollection<Product> Products { get; set; } = new();
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
    public decimal TotalPrice => OrderItems.Sum( oi => oi.Quantity * oi.Product.Price);
    public ObservableCollection<Table> Tables { get; set; } = new();
    public Table SelectedTable
    {
        get => _selectedTable;
        set => SetField(ref _selectedTable, value);
    }
    public ObservableCollection<OrderItem> OrderItems { get; set; } = new();
    public OrderItem? SelectedOrderItem
    {
        get => _selectedOrderItem;
        set => SetField(ref _selectedOrderItem, value);
    }
    public ObservableCollection<OrderView> UncompletedOrders { get; set; } = new();
    public ObservableCollection<OrderView> CompletedOrders { get; set; } = new();
    public OrderView? SelectedUncompletedOrder
    {
        get => _selectedUncompletedOrder;
        set => SetField(ref _selectedUncompletedOrder, value);
    }
    public OrderView? SelectedCompletedOrder { 
        get => _selectedCompletedOrder;
        set => SetField(ref _selectedCompletedOrder, value);
    }

    public List<string> PaymentMethods { get; set; } = ["Cash", "Credit Card", "Mobile payment", "QR payment"];
    public string SelectedPaymentMethod { get; set; } = "Cash";
    
    public ICommand IncrementAmountCommand { get; set; }
    public ICommand DecrementAmountCommand { get; set; }
    public ICommand ToOrderListCommand { get; set; }
    public ICommand CreateOrderCommand { get; set; }
    public ICommand CompleteOrderCommand { get; set; }
    
    public MainViewModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        
        IncrementAmountCommand = new RelayCommand(_ => ProductAmount++, _ => SelectedProduct != null );
        DecrementAmountCommand = new RelayCommand(_ => ProductAmount--, _ => SelectedProduct != null && ProductAmount > 1 );
        ToOrderListCommand = new RelayCommand(_ => OrderItems.Add(new(){ Quantity = ProductAmount, Product = SelectedProduct! }),  _ => SelectedProduct != null);
        CreateOrderCommand = new RelayCommand(_ => UncompletedOrders.Add(CreateOrderView()), _ => OrderItems.Count > 0);
        CompleteOrderCommand = new RelayCommand(_ => CompleteOrder(), _ => SelectedUncompletedOrder != null);
 
        LoadCategories();
        LoadTables();
        LoadEmployees();
        
        SelectedCategory = Categories[0];
        SelectedTable = Tables[0];
        
        OrderItems.CollectionChanged += (s, e) =>
        {
            OnPropertyChanged(nameof(TotalPrice));
        };
        //
        // UncompletedOrders.CollectionChanged += (s, e) =>
        // {
        //     _dbContext.Tables.Update(SelectedTable);
        //     _dbContext.Customers.Update(SelectedTable.Customer!);
        //     _dbContext.SaveChanges();
        //     LoadTables();
        //     SelectedTable = Tables[0];
        // };
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
    private void LoadProducts(int categoryId)
    {
        var products = _dbContext.Products.Where(p => p.CategoryId == categoryId);
        
        Products.Clear();

        foreach (var product in products)
        {
            Products.Add(product);
        }
    }
    private void LoadTables()
    {
        var tables = _dbContext.Tables.Where(t => t.Customer == null);
        
        Tables.Clear();

        foreach (var table in tables)
        {
            Tables.Add(table);
        }
    }

    private void LoadEmployees()
    {
        var employees = _dbContext.Employees.ToList();

        _employees.Clear();
        
        foreach (var employee in employees)
        {
            _employees.Add(employee);
        }
    }
    private OrderView CreateOrderView()
    {
        var order = new Order();
        
        order.OrderItems = new List<OrderItem>();

        foreach (var orderItem in OrderItems)
        {
            order.OrderItems.Add(orderItem);
        }
        
        order.CreatedAt = DateTime.Now;
        order.IsCompleted = false;
        order.OrderedBy = _dbContext.Customers.First(c => c.Table == null);
        order.OrderedBy.Table = SelectedTable;
        SelectedTable.Customer = order.OrderedBy;
        order.OrderedBy.Table = SelectedTable;
        _dbContext.Tables.Update(SelectedTable);
        _dbContext.Customers.Update(order.OrderedBy);
        _dbContext.SaveChanges();
        Tables.Remove(SelectedTable);
        SelectedTable = Tables[0];
        order.ServicedBy = _employees[new Random().Next(0, _employees.Count)];
     
        
        OrderItems.Clear();
        
        return new(order);
    }
    private OrderView CompleteOrder()
    {
        SelectedUncompletedOrder!.Order.IsCompleted = true;
        SelectedUncompletedOrder.Order.OrderedBy.Table!.Customer = null;
        SelectedUncompletedOrder.Order.OrderedBy.Table = null;
        
        SelectedUncompletedOrder.Order.CompletedAt = DateTime.Now;
        SelectedUncompletedOrder.Order.Payment = new Payment { PaymentMethod = SelectedPaymentMethod };
        
        CompletedOrders.Add(SelectedUncompletedOrder);
        UncompletedOrders.Remove(SelectedUncompletedOrder);

        return CompletedOrders.Last();
    }
}


