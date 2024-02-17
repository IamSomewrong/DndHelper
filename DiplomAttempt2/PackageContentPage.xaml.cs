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
        var name = await DisplayPromptAsync("Новый пакет", "Введите название:");
        App.Packages.Packages.Add(new Package() { Name = name });
        var writeData = JsonSerializer.Serialize(App.Packages);
        File.WriteAllText(App._fileName, writeData);
    }
}