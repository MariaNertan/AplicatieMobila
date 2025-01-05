using AplicatieMobila.ViewModels;

namespace AplicatieMobila;

public partial class BouquetsPage : ContentPage
{
	public BouquetsPage()
	{
		InitializeComponent();
        BindingContext = new BouquetsViewModel();

    }
}