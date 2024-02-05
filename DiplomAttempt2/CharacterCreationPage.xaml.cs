using DiplomAttempt2.Models;
using System.Collections.ObjectModel;


namespace DiplomAttempt2;

public partial class CharacterCreationPage : ContentPage
{
	ObservableCollection<Character> _characters;
	public CharacterCreationPage(IEnumerable<Character> characters)
    {
		InitializeComponent();
		_characters = (ObservableCollection<Character>)characters;
	}

	public async void EndCreation(object sender, EventArgs e)
	{
		_characters.Add(new Character() {Name = NameEntry.Text, Class = ClassEntry.Text, Race = RaceEntry.Text});
        await Navigation.PopAsync();
	}
}