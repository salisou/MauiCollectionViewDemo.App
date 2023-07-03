namespace MauiCollectionViewDemo.MVVM.Views;

public partial class EmptyView : ContentPage
{
	public EmptyView()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        // if Checked result = NoResultsView if switch not activate = ConnectivityIssue

        var isTaggled = e.Value;
		collectionView.EmptyView = isTaggled ? Resources["NoResultsView"] :
			Resources["ConnectivityIssue"];
    }
}