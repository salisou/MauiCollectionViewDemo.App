using MauiCollectionViewDemo.MVVM.Views;

namespace MauiCollectionViewDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new DataView();
		//MainPage = new LayoutsPage();
		MainPage = new EmptyView();
		//MainPage = new ProductsView();
	}
}
