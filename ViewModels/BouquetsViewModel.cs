using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;
using AplicatieMobila.Models;

namespace AplicatieMobila.ViewModels
{
    public class BouquetsViewModel : BaseViewModel
    {
        public ObservableCollection<Bouquet> Bouquets { get; set; }
        public ICommand AddToCartCommand { get; }

        public BouquetsViewModel()
        {
            Bouquets = new ObservableCollection<Bouquet>
            {
                new Bouquet { Name = "Buchet 1", Price = 150.00m, ImageUrl = "unu.jpg" },
                new Bouquet { Name = "Buchet 2", Price = 200.00m, ImageUrl = "doi.jpg" },
                new Bouquet { Name = "Buchet 3", Price = 250.00m, ImageUrl = "trei.jpg" }
            };


            AddToCartCommand = new Command<Bouquet>(async bouquet =>
            {
                var flower = new Flower
                {
                    Name = bouquet.Name,
                    Price = bouquet.Price,
                    ImageUrl = bouquet.ImageUrl
                };
            
            App.CartViewModel.AddToCart(flower);

            // Afișează un mesaj de confirmare
            await Application.Current.MainPage.DisplayAlert( 
                "Adaugat în cos",
                $"Buchetul \"{bouquet.Name}\" a fost adăugat în coș!",
                "OK"
            );
        });

        }

        private void AddToCart(Bouquet bouquet)
        {
            App.CartViewModel.AddToCart(bouquet);
        }
    }

    public class Bouquet
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
