using ProductManager.Models;
using System.Collections.ObjectModel;

namespace ProductManager;

public partial class MainPage : ContentPage
{

    ObservableCollection<Product> products;
    ObservableCollection<Product> Products { get { return products; } }

    public MainPage()
    {
        for (int i = 0; i < 100; i++)
        {
            DB.Products.Add(new Product($"Product {i}", i));
        }
        products = new ObservableCollection<Product>(DB.Products);
        InitializeComponent();
        ProductsListView.ItemsSource = products;
    }

    private async void OnProductSelected(object sender, SelectedItemChangedEventArgs args)
    {
        Product selectedProduct = args.SelectedItem as Product;
        await Navigation.PushAsync(new DetailPage(selectedProduct));
    }

    private async void OnAddClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("/add");
    }
}