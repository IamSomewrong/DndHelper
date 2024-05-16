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
        PackageView.ItemsSource = ContentManager.Packages;
    }

    private async void CreatePackage(object sender, EventArgs e)
    {
        //_editMode = false;
        string name = await DisplayPromptAsync("Создание пакета", "Введите название:");
        if(!String.IsNullOrWhiteSpace(name))
        {
            ContentManager.CreatePackage(name);
        }        
    }
    private async void ChoosePackage(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new PackagePage(ContentManager.Packages[e.ItemIndex]));
    }
}