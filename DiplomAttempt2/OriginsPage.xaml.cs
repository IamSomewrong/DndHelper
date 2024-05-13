using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DiplomAttempt2;

public partial class OriginsPage : ContentPage
{
    ObservableCollection<Origin> _origins;

    public OriginsPage(ObservableCollection<Origin> origins)
	{
		InitializeComponent();
        _origins = origins;
        OriginsView.ItemsSource = origins;
    }

    private async void CreateClicked(object sender, EventArgs e)
    {
        string name = await DisplayPromptAsync("Создание происхождения", "Введите название:");
        if (!String.IsNullOrWhiteSpace(name))
        {
           Origin origin = new Origin() {
               Name = name,
               Skills = new ObservableCollection<Skill>(),
               Gears = new ObservableCollection<Gear>(),
               GearsForInventory = new ObservableCollection<Gear>(),
               Traits = new ObservableCollection<string>()
           };
            _origins.Add(origin);
            App.SavePackages();
        }
    }
    private async void ToOrigin(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new OriginPage(_origins[e.ItemIndex]));
    }
}