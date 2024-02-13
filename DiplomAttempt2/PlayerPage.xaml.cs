using DiplomAttempt2.Models;
using System.Collections.ObjectModel;

namespace DiplomAttempt2;

public partial class PlayerPage : ContentPage
{
	public ObservableCollection<Character> Characters {  get; set; }

    public PlayerPage()
	{
		InitializeComponent();
		Characters = new ObservableCollection<Character>() { new Character() {Name = "Hero", Race = "Elf", Class = "Mage" } };
		CharacterView.ItemsSource = Characters;
	}

	public async void CreateCharacter(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CharacterCreationPage(Characters));
    }
}