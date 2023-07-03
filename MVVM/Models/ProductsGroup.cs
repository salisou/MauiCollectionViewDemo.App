using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCollectionViewDemo.MVVM.Models
{
    public class ProductsGroup: List<Product>
    {
        public string Name { get; set; }
        public ProductsGroup(string name, List<Product> products): base(products)
        {
            Name = name;
        }

    }
}
