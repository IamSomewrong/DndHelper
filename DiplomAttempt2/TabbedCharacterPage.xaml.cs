using DiplomAttempt2.Models;

namespace DiplomAttempt2;

public partial class TabbedCharacterPage : TabbedPage
{
	public Character Character;
	public TabbedCharacterPage(Character character)
	{
		
		InitializeComponent();
		Character = character;
		foreach(ICharacterPage page in Children)
		{
			page.character = Character;
			page.Initialize();
		}
	}
}