using MauiCollectionViewDemo.MVVM.ViewModels;

namespace MauiCollectionViewDemo.MVVM.Views;

public partial class DataView : ContentPage
{
	public DataView()
	{
		InitializeComponent();
		BindingContext = new DataViewModel();

    }
}