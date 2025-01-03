using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AplicatieMobila.ViewModels;

public class AboutViewModel
{
    public ObservableCollection<Flower> Flowers { get; set; }
    public ICommand AddToCartCommand { get; }

    public AboutViewModel()
    {
        Flowers = new ObservableCollection<Flower>
        {
            new Flower { Name = "Trandafir", Price = 10, ImageUrl = "trandafir.png" },
            new Flower { Name = "Lalea", Price = 7, ImageUrl = "lalea.png" },
            new Flower { Name = "Crin", Price = 12, ImageUrl = "crin.png" }
        };

        AddToCartCommand = new Command<Flower>(async (flower) => await AddToCart(flower));

    }

    private async Task AddToCart(Flower flower)
    {
        App.CartViewModel.AddToCart(flower);
        await Application.Current.MainPage.DisplayAlert("Succes", $"{flower.Name} a fost adaugat in cos!", "OK");

    }
}

