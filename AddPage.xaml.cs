using ProductManager.Models;

namespace ProductManager;

public partial class AddPage : ContentPage
{
    private Product product { get; set; }

    public AddPage()
    {
        InitializeComponent();
        product = new Product("", 0, 0, true, new DateTime(2021, 1, 1), "");
    }

    private async void OnSubmitClick(object sender, EventArgs e)
    {
        MainPage.products.Add(product);
        await Navigation.PushAsync(new DetailPage(product));
    }

    private void OnNameEntryChange(object sender, TextChangedEventArgs e)
    {
        product.Name = e.NewTextValue;
    }

    private void OnPriceSliderChange(object sender, ValueChangedEventArgs e)
    {
        product.Price = (int)e.NewValue;
        Label label = (Label)FindByName("priceLabel");
        label.Text = $"Price: {product.Price.ToString()}";
    }

    void OnToggled(object sender, ToggledEventArgs e)
    {
        product.InProduction = e.Value;
        Label label = (Label)FindByName("inProductionLabel");
        label.Text = $"In Production: {product.InProduction.ToString()}";
    }

    private void OnNameEntryCompleted(object sender, EventArgs e)
    {
        product.Name = ((Entry)sender).Text;
    }

    private void OnStockEntryChange(object sender, TextChangedEventArgs e)
    {
        try
        {

            product.Stock = Convert.ToInt32(e.NewTextValue);
        }
        catch (Exception)
        {
            Console.WriteLine("exception");
        }
    }

    private void OnStockEntryCompleted(object sender, EventArgs e)
    {
        product.Stock = Convert.ToInt32(((Entry)sender).Text);
    }
}

