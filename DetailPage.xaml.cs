using ProductManager.Models;

namespace ProductManager;

public partial class DetailPage : ContentPage
{
    public DetailPage(Product product)
    {
        InitializeComponent();
        header.Title = product.Name;
        nameLabel.Text += product.Name;
        stockLabel.Text += product.Stock;
        priceLabel.Text += product.Price;
        inProductionLabel.Text += product.InProduction ? "Yes" : "No";
        releaseDateLabel.Text += product.ReleaseDate.ToString("d");
        typeLabel.Text += product.Type;
    }
}