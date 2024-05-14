using DiplomAttempt2.Models;
using System.Collections.ObjectModel;

namespace DiplomAttempt2;

public partial class PlayerPage : ContentPage
{
    public PlayerPage()
	{
		InitializeComponent();
		CharacterView.ItemsSource = App.Characters;
	}

	public async void CreateCharacter(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CharacterCreationPage(App.Characters));
    }

    private async void CharacterView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		await Navigation.PushAsync(new СharacterPage(App.Characters[e.ItemIndex]));
    }
}