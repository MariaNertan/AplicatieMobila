using AplicatieMobila.Models;
using AplicatieMobila.ViewModels;

namespace AplicatieMobila;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        BindingContext = new AboutViewModel(); // sau orice ViewModel ai folosi
    }

    private async void OnViewCartClicked(object sender, EventArgs e)
    {
        // Navigheaz? c?tre pagina CartPage
        await Navigation.PushAsync(new CartPage());
    }
}