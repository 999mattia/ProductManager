using ProductManager.Models;

namespace ProductManager;

public partial class DetailPage : ContentPage
{
    private Product product { get; set; }
    public DetailPage(Product product)
    {
        InitializeComponent();
        this.product = product;
        header.Title = product.Name;
        nameLabel.Text += product.Name;
        stockLabel.Text += product.Stock;
        priceLabel.Text += product.Price;
        inProductionLabel.Text += product.InProduction ? "Yes" : "No";
        releaseDateLabel.Text += product.ReleaseDate.ToString("d");
        typeLabel.Text += product.Type;
    }

    private async void OnDeleteClick(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Alert", "Are you sure you want to delete this product?", "Yes", "No");
        if (answer)
        {
            MainPage.products.Remove(MainPage.products.Where(p => p.Name == header.Title).First());
            await Navigation.PopAsync();
        }
    }

    private async void OnEditClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditPage(product));
    }
}