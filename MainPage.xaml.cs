﻿using ProductManager.Models;
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
            products.Add(new Product($"Product {i}", i));
        }
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