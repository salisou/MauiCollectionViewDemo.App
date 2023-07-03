using MauiCollectionViewDemo.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiCollectionViewDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DataViewModel
    {
        private Product selectedProduct;
        //private List<Product> selectedProducts;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public bool IsRefreshing { get; set; }

        public Product SelectedProduct
        {
            get => selectedProduct; 
            set
            {
                selectedProduct = value;
            }
        }



        #region Command
        public ICommand RefreshCommand =>
            new Command(async () =>
            {
                IsRefreshing = true;
                await Task.Delay(3000);
                RefreshItems();
                IsRefreshing = false;
            });

        public ICommand ThresholdReachedCommand =>
            new Command(() =>
            {
                RefreshItems(Products.Count);
            });

        public ICommand DeleteCommand =>
            new Command((p) =>
            {
                Products.Remove((Product)p);
            });

        public ICommand ProductChangedCommand =>
            new Command(() =>
            {
                var selectedProduct = SelectedProduct;
                
            });
        public List<object> SelectedProducts { get; set; } = 
            new List<object>();

        public ICommand ProducstChangedCommand =>
            new Command(() =>
            {
                var productsList = SelectedProducts;

            });

        public ICommand ClearCommand =>
            new Command(() =>
            {
                SelectedProducts = null;
            });
        #endregion End Command 
        public DataViewModel()
        {
            RefreshItems();
            SelectedProducts.Add(Products.Skip(5).FirstOrDefault());
            SelectedProducts.Add(Products.Skip(7).FirstOrDefault());

            SelectedProduct = Products.Skip(2).FirstOrDefault();
        }

        private void RefreshItems(int lastIndex = 0)
        {
            int numberOfItemsPerPage = 5;
            var items = new ObservableCollection<Product>
            {
               new Product
                {
                    Name = "Yogurt",
                    Price = 60.0m,
                    Image = "yogurt",
                    HasOffer = false,
                    Stock = 28
                },

                new Product
                {
                    Name = "watermelon",
                    Price = 30.0m,
                    Image = "Watermelon",
                    HasOffer = false,
                    Stock = 87
                },

                new Product
                {
                    Name = "Weter Bottle",
                    Price = 80.0m,
                    Image = "weterbottle",
                    HasOffer = true,
                    OfferPrice = 60.99m,
                    Stock = 33
                },

                new Product
                {
                    Name = "Pineapple",
                    Price = 49.0m,
                    Image = "pineapple",
                    HasOffer = false,
                    Stock = 41
                },

                new Product
                {
                    Name = "Pepper",
                    Price = 60.0m,
                    Image = "pepper",
                    HasOffer = true,
                    OfferPrice = 1.00m,
                    Stock = 64
                },

                new Product
                {
                    Name = "Pasta",
                    Price = 52.0m,
                    Image = "pasta",
                    HasOffer = false,
                    Stock = 65
                },

                new Product
                {
                    Name = "Tomatto",
                    Price = 120.0m,
                    Image = "tomato",
                    HasOffer = false,
                    Stock = 0
                },

                new Product
                {
                    Name = "Tea",
                    Price = 65.0m,
                    Image = "tea",
                    HasOffer = false,
                    Stock = 82
                },

                new Product
                {
                    Name = "Speckling Drink",
                    Price = 35.0m,
                    Image = "specklingdrink",
                    HasOffer = true,
                    OfferPrice = 2.99m,
                    Stock = 52
                },

                new Product
                {
                    Name = "Bananas",
                    Price = 1.99m,
                    Image = "bananas",
                    HasOffer = true,
                    OfferPrice = 0.99m,
                    Stock = 100
                },

                new Product
                {
                    Name = "Avocado",
                    Price = 2.99m,
                    Image = "avocado",
                    HasOffer = true,
                    OfferPrice = 2.50m,
                    Stock = 100
                },

                new Product
                {
                    Name = "Guinness",
                    Price = 3.99m,
                    Image = "guinness",
                    HasOffer = false,
                    Stock = 150
                },
            };

            var pageItems = items
                .Skip(lastIndex)
                .Take(numberOfItemsPerPage);

            foreach (var item in pageItems)
            {
                Products.Add(item);
            }
        }
    }
}
