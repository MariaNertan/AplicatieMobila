using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieMobila.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;

namespace AplicatieMobila.ViewModels;

public class CartViewModel : BaseViewModel
{
    public ObservableCollection<CartItem> CartItems { get; set; }
    public double TotalAmount
    {
        get
        {
            // Actualizează totalul bazat pe cartItems
            return CartItems.Sum(item => (double)item.TotalPrice);
        }
    }

    // Declarațiile pentru comenzi
    public ICommand UpdateQuantityCommand { get; }
    public ICommand RemoveFromCartCommand { get; }
    public CartViewModel()
    {
        CartItems = new ObservableCollection<CartItem>();

        // Inițializarea comenzilor
        UpdateQuantityCommand = new Command<Tuple<CartItem, int>>((param) =>
        {
            if (param != null)
            {
                UpdateQuantity(param.Item1, param.Item2);
            }
        });

        RemoveFromCartCommand = new Command<CartItem>(RemoveFromCart);
    }



    public void AddToCart(object item)
    {
        if (item is Flower flower)
        {
            var existingItem = CartItems.FirstOrDefault(cartItem => cartItem.Name == flower.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.TotalPrice += (decimal)flower.Price;
                Debug.WriteLine($"Updated {flower.Name} in cart. Quantity: {existingItem.Quantity}, TotalPrice: {existingItem.TotalPrice}");

            }
            else
            {
                CartItems.Add(new CartItem
                {
                    Name = flower.Name,
                    Quantity = 1,
                    Price = (decimal)flower.Price,  // Setează prețul unității
                    TotalPrice = (decimal)flower.Price
                });
                Debug.WriteLine($"Added {flower.Name} to cart.");

            }
        }
        else if (item is Bouquet bouquet)
        {
            var existingItem = CartItems.FirstOrDefault(cartItem => cartItem.Name == bouquet.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.TotalPrice += (decimal)bouquet.Price;
                Debug.WriteLine($"Updated {bouquet.Name} in cart. Quantity: {existingItem.Quantity}, TotalPrice: {existingItem.TotalPrice}");

            }
            else
            {
                CartItems.Add(new CartItem
                {
                    Name = bouquet.Name,
                    Quantity = 1,
                    TotalPrice = (decimal)bouquet.Price
                });
                Debug.WriteLine($"Added {bouquet.Name} to cart.");

            }
        }

        OnPropertyChanged(nameof(CartItems));
        OnPropertyChanged(nameof(TotalAmount)); // Actualizează totalul
    }

    // Metoda pentru actualizarea cantității unui produs
    public void UpdateQuantity(CartItem item, int newQuantity)
    {
        if (item != null && newQuantity > 0)
        {
            item.Quantity = newQuantity;
            // Actualizează lista și totalul
            OnPropertyChanged(nameof(CartItems));
            OnPropertyChanged(nameof(TotalAmount));
        }
    }


    public void RemoveFromCart(CartItem item)
    {
        CartItems.Remove(item);
        OnPropertyChanged(nameof(CartItems));
        OnPropertyChanged(nameof(TotalAmount));
    }

    // Adăugarea apelului public pentru OnPropertyChanged
    public new void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);
    }

}

public class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Price { get; set; }  // Adaugă această proprietate

}

public class Flower
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } // Proprietate pentru URL-ul imaginii

}