using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieMobila.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AplicatieMobila.ViewModels;

public class CartViewModel : BaseViewModel
{
    public ObservableCollection<CartItem> CartItems { get; set; }
    public double TotalAmount => (double)CartItems.Sum(item => item.TotalPrice);

    public CartViewModel()
    {
        CartItems = new ObservableCollection<CartItem>();
    }

    public void AddToCart(Flower flower)
    {
        var existingItem = CartItems.FirstOrDefault(item => item.Name == flower.Name);
        if (existingItem != null)
        {
            existingItem.Quantity++;
            existingItem.TotalPrice += flower.Price;
        }
        else
        {
            CartItems.Add(new CartItem
            {
                Name = flower.Name,
                Quantity = 1,
                TotalPrice = flower.Price
            });
        }
        OnPropertyChanged(nameof(TotalAmount)); // Actualizează totalul

    }
}

public class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}

public class Flower
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } // Proprietate pentru URL-ul imaginii

}