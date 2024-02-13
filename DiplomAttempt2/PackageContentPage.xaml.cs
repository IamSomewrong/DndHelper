using System.Collections.ObjectModel;
using System.Text.Json;
using DiplomAttempt2.Models;

namespace DiplomAttempt2;
public partial class PackageContentPage : ContentPage
{
    public PackageContentPage()
	{
		InitializeComponent();
        PackageView.ItemsSource = App.Packages.Packages;
    }

    public async void CreatePackage(object sender, EventArgs e)
    {
        //диалог с названием и создание пакета
    }
}