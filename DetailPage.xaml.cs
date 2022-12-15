using ProductManager.Models;

namespace ProductManager;

public partial class DetailPage : ContentPage
{
    public DetailPage(Product product)
    {
        InitializeComponent();
        header.Title = product.Name;
    }
}