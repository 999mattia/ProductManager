using ProductManager.Models;

namespace ProductManager;

public partial class AddPage : ContentPage
{
    private Product product { get; set; }

    Product defaultProduct = new Product("", 0, 0, true, new DateTime(2021, 1, 1), "");

    public AddPage()
    {
        InitializeComponent();
        product = defaultProduct;
    }



    private bool CheckInput()
    {
        List<string> errorMessages = new List<string>();

        if (product.Name.Count() < 3)
        {
            errorMessages.Add("Name has to be at least 3 characters long");
        }

        if (product.Stock == 0)
        {
            errorMessages.Add("Stock has to be set and greater than 0");
        }

        if (product.Type == "")
        {
            errorMessages.Add("Type has to be selected");
        }



        if (errorMessages.Count > 0)
        {
            string errors = "";

            foreach (string error in errorMessages)
            {
                errors += error + "\n";

            }
            DisplayAlert("Alert", $"{errors}", "OK");

            return false;
        }
        else
        {
            return true;
        }
    }


    private async void OnSubmitClick(object sender, EventArgs e)
    {
        if (CheckInput() == true)
        {
            MainPage.products.Add(product);
            product = defaultProduct;
            await Navigation.PushAsync(new DetailPage(product));

        }
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

    void OnPickerChange(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex == 0)
        {
            product.Type = "Drohne";
        }
        if (picker.SelectedIndex == 1)
        {
            product.Type = "Modelleisenbahn";
        }
        if (picker.SelectedIndex == 2)
        {
            product.Type = "Sonstiges";
        }
    }

    private void OnStockEntryCompleted(object sender, EventArgs e)
    {
        product.Stock = Convert.ToInt32(((Entry)sender).Text);
    }
}

