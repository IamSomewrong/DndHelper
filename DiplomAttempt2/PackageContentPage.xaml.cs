using System.Collections.ObjectModel;
using System.Text.Json;
using DiplomAttempt2.Models;

namespace DiplomAttempt2;
public partial class PackageContentPage : ContentPage
{
    public PackageContentPage()
	{
		InitializeComponent();
        PackageView.ItemsSource = App.Packages;
    }

    public async void CreatePackage(object sender, EventArgs e)
    {
        var name = await DisplayPromptAsync("Новый пакет", "Введите название:");
        if(name.Length > 0) 
        {
            Package package = new Package() { 
                Name = name, 
                Classes = new ObservableCollection<Class>(),
                Races = new ObservableCollection<Race>(),
                Items = new ObservableCollection<Item>(),
                Enemies = new ObservableCollection<Enemy>(),
                Spells = new ObservableCollection<Spell>(),
            };
            App.Packages.Add(package);
            var writeData = JsonSerializer.Serialize(package);
            File.WriteAllText(FileSystem.AppDataDirectory + "/" + name + ".pckg", writeData);
        }
        
    }

    public async void OpenPackage(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new PackagePage(App.Packages[e.ItemIndex]));
    }
}