using MauiCollectionViewDemo.MVVM.ViewModels;
using System.Diagnostics;
using static Java.Util.Jar.Attributes;

namespace MauiCollectionViewDemo.MVVM.Views;

public partial class ProductsView : ContentPage
{
	public ProductsView()
	{
		InitializeComponent();
		BindingContext = new ProductsViewMode();
    }

    /// <summary>
    /// how to obtain values from the control when the scrolling
    /// 
    /// The event handler receives a parameter of type items view scrolled event args, which has information
    /// in its properties about different values of the collection view.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        Debug.Write("-------------------------------------------------");
        Debug.WriteLine("HorizontalDelta:" + e.HorizontalDelta);
        Debug.WriteLine("VerticalDelta" + e.VerticalDelta);
        Debug.WriteLine("HorizontalOffset" + e.HorizontalOffset);
        Debug.WriteLine("VerticalOffset" + e.VerticalOffset);
        Debug.WriteLine("FirstVisibleItemIndex" + e.FirstVisibleItemIndex);
        Debug.WriteLine("CenterItemIndex" + e.CenterItemIndex);
        Debug.WriteLine("LastVisibleItemIndex" + e.LastVisibleItemIndex);
        Debug.Write("-------------------------------------------------");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //to obtain the associated view.
        //Muddle through the declaration of a variable called VM.
        var vm = BindingContext as ProductsViewMode;

        // obtain the reference of a product to navigate to it.
        //I will navigate to the product with the ID equal to 7.
        var product = vm.Products.SelectMany(p => p)
            .FirstOrDefault(x => x.Id == 10);


        //This we are simulating the addition of a new grouping to the collection view.
        vm.Products.Add(new Models.ProductsGroup("New Group",
            new List<Models.Product>
            {
                new Models.Product
                {
                    Id = 100,
                    Name = "Bitcoint",
                    Price = 99999
                }
            })); 

        /*
            Use an overload in which we do not pass an index,
            but we pass the reference of the element to which
            we want to navigate.
         */
        //collectionView.ScrollTo(product, animate: false, position: ScrollToPosition.Center);
    }
}