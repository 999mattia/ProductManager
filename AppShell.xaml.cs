namespace ProductManager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        Routing.RegisterRoute("details", typeof(DetailPage));
        Routing.RegisterRoute("add", typeof(AddPage));
        Routing.RegisterRoute("edit", typeof(EditPage));
        InitializeComponent();
    }
}