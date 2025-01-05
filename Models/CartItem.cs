using System.ComponentModel;

namespace AplicatieMobila.Models;

public class CartItem : INotifyPropertyChanged
{
    private int quantity;
   // private decimal totalPrice;
    private decimal price;  // Adăugăm proprietatea Price pentru prețul unitar


    public string Name { get; set; }

    public int Quantity
    {
        get => quantity;
        set
        {
            if (quantity != value)
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalPrice)); // Actualizează TotalPrice când cantitatea se schimbă
            }
        }
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (price != value)
            {
                price = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(TotalPrice)); // Recalculează TotalPrice
            }
        }
    }

    public decimal TotalPrice => price * quantity; // Calculează automat TotalPrice pe baza Price și Quantity
   


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
