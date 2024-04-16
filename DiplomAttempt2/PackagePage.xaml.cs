namespace DiplomAttempt2;
using DiplomAttempt2.Models;
using System.Collections.ObjectModel;

public partial class PackagePage : ContentPage
{
	Package _package;
	public PackagePage(Package package)
	{
		InitializeComponent();
		_package = package;
		Title = package.Name;
    }

    private async void ToFeatsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FeatsPage(_package.Feats));
    }

    private async void ToRacesPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RacesPage(_package.Races));
    }
}