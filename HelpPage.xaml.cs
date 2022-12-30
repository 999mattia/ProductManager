using ProductManager.Models;

namespace ProductManager;

public partial class HelpPage : ContentPage
{
    public HelpPage()
    {
        InitializeComponent();
    }

    private void OnSubmitClick(object sender, EventArgs e)
    {
        DisplayAlert("Thanks", "I appreciate your feedback", "OK");
        checkbox.IsChecked = false;
    }
}

