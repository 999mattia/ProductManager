using ProductManager.Models;
using System.Collections.ObjectModel;

namespace ProductManager;

public partial class MainPage : ContentPage
{
	ObservableCollection<Product> products = new();
	ObservableCollection<Product> Products { get { return products; } }

	public MainPage()
	{
		InitializeComponent();
		products.Add(new Product("Test", 1));
        products.Add(new Product("Test2", 2));
        products.Add(new Product("Test3", 3));
        products.Add(new Product("Test4", 4));
        products.Add(new Product("Test5", 5));
        ProductsListView.ItemsSource= products;
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

