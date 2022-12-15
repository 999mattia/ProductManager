using ProductManager.Models;

namespace ProductManager;

public partial class AddPage : ContentPage
{
    private Product product { get; set; }
    public AddPage()
    {
        InitializeComponent();
        product = new Product("", 0);
    }

    private void OnNameEntryChange(object sender, TextChangedEventArgs e)
    {
        product.Name = e.NewTextValue;
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

