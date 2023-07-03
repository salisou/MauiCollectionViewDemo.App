using MauiCollectionViewDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCollectionViewDemo.MVVM.ViewModels
{
    public class ProductsViewMode
    {
        public ObservableCollection<ProductsGroup> Products { get; set; } = new ObservableCollection<ProductsGroup>();

        public ProductsViewMode() 
        {
            var products = LoadItems();

            var grouped = 
                from p in products
                orderby p.Name
                group p by p.Name[0].ToString()
                into groups 
                select new ProductsGroup(groups.Key, groups.ToList());

            int id = 0;
            foreach (var group in grouped)
            {
                foreach (var product in group)
                {
                    product.Id = id;
                    id++;
                }
            }

            Products = new ObservableCollection<ProductsGroup>(grouped.ToList());
        }
        
        //T is a type representing a single group
        private List<Product> LoadItems()
        {
            return new List<Product>
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
        }
    }
}
