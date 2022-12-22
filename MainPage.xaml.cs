using ProductManager.Models;
using System.Collections.ObjectModel;

namespace ProductManager;

public partial class MainPage : ContentPage
{

    public static ObservableCollection<Product> products;
    ObservableCollection<Product> Products { get { return products; } }

    public MainPage()
    {
        products = new ObservableCollection<Product>();
        for (int i = 1; i <= 10; i++)
        {
            products.Add(new Product($"Product {i}", i, i, true, new DateTime(2021, 1, 1), "Drohne"));
        }
        InitializeComponent();
        ProductsListView.ItemsSource = products;
    }

    private async void OnProductSelected(object sender, SelectedItemChangedEventArgs args)
    {
        Product selectedProduct = args.SelectedItem as Product;
        await Navigation.PushAsync(new DetailPage(selectedProduct));
    }
}