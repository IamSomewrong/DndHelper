using System.Collections.ObjectModel;
using System.Text.Json;
using DiplomAttempt2.Models;

namespace DiplomAttempt2;
public partial class UserContentPage : ContentPage
{
    //bool _editMode = false;
    public UserContentPage()
	{
		InitializeComponent();
        PackageView.ItemsSource = App.Packages;
    }

    private async void CreatePackage(object sender, EventArgs e)
    {
        //_editMode = false;
        string name = await DisplayPromptAsync("Новый пакет", "Введите название:");
        if(!String.IsNullOrWhiteSpace(name))
        {
            Package package = new Package() { 
                Name = name,
                Classes = new ObservableCollection<Class>(),
                Races = new ObservableCollection<Race>(),
                Items = new ObservableCollection<Item>(),
                Enemies = new ObservableCollection<Enemy>(),
                Spells = new ObservableCollection<Spell>(),
                Feats = new ObservableCollection<Feat>(),
                Origins = new ObservableCollection<Origin>(),
            };
            App.Packages.Add(package);
            var writeData = JsonSerializer.Serialize(package);
            File.WriteAllText(FileSystem.AppDataDirectory + "/" + name + ".pckg", writeData);
        }        
    }
    private async void ChoosePackage(object sender, ItemTappedEventArgs e)
    {
        //if(!_editMode)
            await Navigation.PushAsync(new PackagePage(App.Packages[e.ItemIndex]));
        //else
        //{

        //}

    }

    //private void EnableEditMode(object sender, EventArgs e)
    //{
    //    EditModeImage.Color = _editMode ? new Color(230, 230, 225) : new Color(80, 80, 10);
    //    _editMode = !_editMode;
    //}
}