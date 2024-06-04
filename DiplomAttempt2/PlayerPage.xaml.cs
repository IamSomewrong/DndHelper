using DiplomAttempt2.Models;
using System.Collections.ObjectModel;

namespace DiplomAttempt2;

public partial class PlayerPage : ContentPage
{
    public PlayerPage()
	{
		InitializeComponent();
		CharacterView.ItemsSource = ContentManager.Characters;
	}

	public async void CreateCharacter(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CharacterCreationPage(ContentManager.Characters));
    }

    private async void CharacterView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		await Navigation.PushAsync(new TabbedCharacterPage(ContentManager.Characters[e.ItemIndex]));
    }
}