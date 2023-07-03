using MauiCollectionViewDemo.MVVM.ViewModels;

namespace MauiCollectionViewDemo.MVVM.Views;

public partial class LayoutsPage : ContentPage
{
	public LayoutsPage()
	{
		InitializeComponent();
		BindingContext = new DataViewModel();
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var element = e.CurrentSelection;
    }
}