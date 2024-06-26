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
    private async void ToClassesPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClassesPage(_package.Classes));
    }

    private async void ToOriginsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OriginsPage(_package.Origins));
    }
}