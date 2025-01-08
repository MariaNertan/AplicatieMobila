using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;
using AplicatieMobila.Models; // Asigură-te că folosești spațiul de nume corect pentru clasa Flower


namespace AplicatieMobila.ViewModels;

public class AboutViewModel : BaseViewModel
{
    public ObservableCollection<Flower> Flowers { get; set; }
    // Lista filtrată
    public ObservableCollection<Flower> FilteredFlowers { get; set; }

    public ICommand AddToCartCommand { get; }

    public AboutViewModel()
    {
        Flowers = new ObservableCollection<Flower>
        {
            new Flower { Name = "Trandafir", Price = 10, ImageUrl = "trandafir.png" },
            new Flower { Name = "Lalea", Price = 7, ImageUrl = "lalea.png" },
            new Flower { Name = "Crin", Price = 12, ImageUrl = "crin.png" },
            new Flower { Name = "Margareta", Price = 8, ImageUrl = "margareta.png" },
            new Flower { Name = "Bujor", Price = 9, ImageUrl = "bujor.png" },
            new Flower { Name = "Zambila", Price = 6, ImageUrl = "zambila.png" },
            new Flower { Name = "Orhidee", Price = 15, ImageUrl = "orhidee.png" },
            new Flower { Name = "Lavanda", Price = 18, ImageUrl = "lavanda.png" },
            new Flower { Name = "Hortensie", Price = 22, ImageUrl = "hortensie.png" },
            new Flower { Name = "Floarea Soarelui", Price = 12, ImageUrl = "floarea_soarelui.png" }



        };

        // Inițial, lista filtrată este identică cu lista completă
        FilteredFlowers = new ObservableCollection<Flower>(Flowers);


        AddToCartCommand = new Command<Flower>(async (flower) => await AddToCart(flower));

    }

    private async Task AddToCart(Flower flower)
    {
        App.CartViewModel.AddToCart(flower);
        await Application.Current.MainPage.DisplayAlert("Succes", $"{flower.Name} a fost adaugat in cos!", "OK");

    }

    // Metoda de filtrare
    public void FilterFlowers(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            // Dacă nu există text de căutare, afișează toate florile
            FilteredFlowers = new ObservableCollection<Flower>(Flowers);
        }
        else
        {
            // Filtrare pe baza textului introdus
            FilteredFlowers = new ObservableCollection<Flower>(
                Flowers.Where(f => f.Name.ToLower().Contains(searchText.ToLower()))
            );
        }

        // Notificare pentru actualizarea interfeței
        OnPropertyChanged(nameof(FilteredFlowers));
    }
}



