using AplicatieMobila.ViewModels;
using System;

namespace AplicatieMobila
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            BindingContext = App.CartViewModel; // Seteaz? BindingContext
        }

        // Func?ie apelat? când se schimb? selec?ia din Picker
        private void OnPickupOptionChanged(object sender, EventArgs e)
        {
            // Verific?m ce op?iune a fost selectat?
           
                DeliveryDatePicker.IsVisible = true;
                DeliveryTimePicker.IsVisible = true;
          
        }

        // Func?ie pentru a confirma comanda
        private async void OnConfirmOrder(object sender, EventArgs e)
        {
             string deliveryMethod = PickupOptionPicker.SelectedItem.ToString();
    DateTime? deliveryDate = DeliveryDatePicker.Date;
    TimeSpan? deliveryTime = DeliveryTimePicker.Time;

    // Verific?m dac? toate câmpurile sunt completate
    if (deliveryDate.HasValue && deliveryTime.HasValue)
    {
        // Confirm?m detaliile comenzii
        await DisplayAlert("Confirmare comand?", $"Metoda de livrare: {deliveryMethod}\n" +
                                                $"Data: {deliveryDate.Value.ToShortDateString()}\n" +
                                                $"Ora: {deliveryTime.Value.ToString(@"hh\:mm")}", "OK");
    }
            else
            {
                // Afi?eaz? mesaj dac? informa?iile nu sunt complete
                await DisplayAlert("Eroare", "Te rugam sa completezi toate campurile.", "OK");
            }
        }

        // Func?ie pentru a te întoarce la pagina de produse
        private async void OnBackToProductsClicked(object sender, EventArgs e)
        {
            // Navigheaz? înapoi la pagina principal? (sau la pagina cu produsele)
            await Navigation.PopAsync();
        }
    }
}
