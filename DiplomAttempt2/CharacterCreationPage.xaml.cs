using DiplomAttempt2.Models;
using DiplomAttempt2.ViewModels;
using CommunityToolkit.Maui;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Behaviors;



namespace DiplomAttempt2;

public partial class CharacterCreationPage : ContentPage
{
	CharacterCreationViewModel _viewmodel;
	ObservableCollection<Character> _characters;
	List<Race> _races = new List<Race>();
	List<Class> _classes = new List<Class>();
	List<Origin> _origins = new List<Origin>();
	ResourceDictionary _globalResouces;
	public CharacterCreationPage(IEnumerable<Character> characters)
    {
		InitializeComponent();
		_viewmodel = (CharacterCreationViewModel)BindingContext;

        _characters = (ObservableCollection<Character>)characters;
		_classes = ContentManager.GetAllClasses();
		_races = ContentManager.GetAllRaces();
		_origins = ContentManager.GetAllOrigins();
		List<string> raceNames = (from r in _races select r.Name).ToList<string>();
		List<string> classNames = (from c in _classes select c.Name).ToList<string>();
		List<string> originNames = (from o in _origins select o.Name).ToList<string>();
 		RacePicker.ItemsSource = raceNames;
		ClassPicker.ItemsSource = classNames;
		OriginPicker.ItemsSource = originNames;

		_globalResouces = Application.Current.Resources.MergedDictionaries.ToList()[0];

    }

	private void OpenClass(object sender, EventArgs e)
	{
		Picker p = (Picker)sender;
		Class chosenClass = _classes[p.SelectedIndex];
		_viewmodel.SkillsCount = chosenClass.SkillsCount;
		ClassLayout.Children.Clear();
		Label text = new Label() { Text = "Выбери "};
		Label remain = new Label();
		remain.SetBinding(Label.TextProperty, "SkillsCount");
		ClassLayout.Children.Add(new StackLayout() { 
			Children = { text, remain }, 
			Orientation = StackOrientation.Horizontal, 
			BackgroundColor = (Color)_globalResouces["Primary"],
			HorizontalOptions = LayoutOptions.Fill,
			Padding = 10
		});
		_viewmodel.SkillsChecked = new Dictionary<Skill, bool>();
		foreach (Skill skill in chosenClass.Skills)
		{
			_viewmodel.SkillsChecked[skill] = false;
			Label label = new Label() { Text = skill.ToString(), HorizontalOptions = LayoutOptions.Fill};
            CheckBox checkBox = new CheckBox() { Color = (Color)_globalResouces["Secondary"] };
			checkBox.Behaviors.Add(new EventToCommandBehavior()
			{
				EventName = "CheckedChanged",
				Command = _viewmodel.CheckSkillCommand,
				CommandParameter = skill
			});
			StackLayout layout = new StackLayout()
			{
				Children = { checkBox, label },
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				BackgroundColor = (Color)_globalResouces["Primary"],
				Padding = 10
				
			};
			ClassLayout.Children.Add(layout);
		}
		
	}

	public async void EndCreation(object sender, EventArgs e)
	{
		Race race = _races[RacePicker.SelectedIndex];
		Class chosenClass = _classes[ClassPicker.SelectedIndex];
		Origin origin = _origins[OriginPicker.SelectedIndex];

		Dictionary<Ability, int> abilities = new Dictionary<Ability, int>
		{
			{Ability.Strength, _viewmodel.Strength + race.AbilityBonuses[0]},
			{Ability.Dexterity, _viewmodel.Dexterity + race.AbilityBonuses[1]},
			{Ability.Constitution, _viewmodel.Constitution + race.AbilityBonuses[2]},
			{Ability.Wisdom, _viewmodel.Wisdom + race.AbilityBonuses[3]},
			{Ability.Intelligence, _viewmodel.Intelligence + race.AbilityBonuses[4]},
			{Ability.Charisma, _viewmodel.Charisma + race.AbilityBonuses[5]}
		};
        Dictionary<Ability, bool> abProficiencies = new Dictionary<Ability, bool>();
		Dictionary<Skill, int> skillProficiencies = new Dictionary<Skill, int>();

		foreach (Ability val in Enum.GetValues(typeof(Ability)))
			abProficiencies.Add(val, chosenClass.SavingThrows.Contains(val));

		foreach(Skill val in Enum.GetValues(typeof(Skill)))
			skillProficiencies.Add(val, 0);
		foreach(Skill val in origin.Skills)
			skillProficiencies[val] += 1;
		foreach(var val in _viewmodel.SkillsChecked)
			if (val.Value)
				skillProficiencies[val.Key] += 1;

		int hits = 0;
		switch (chosenClass.HitDice)
		{
			case Dice.K4:
				hits = 4;
				break;

            case Dice.K6:
                hits = 6;
                break;

            case Dice.K8:
                hits = 8;
                break;

            case Dice.K10:
                hits = 10;
                break;

            case Dice.K12:
                hits = 12;
                break;

            case Dice.K20:
                hits = 20;
                break;
        }
		hits += (abilities[Ability.Constitution] - 10) / 2;

        _characters.Add(new Character() {
			Name = NameEntry.Text, 
			Race = race,
			Class = chosenClass,
			Origin = origin,
			Abilities = abilities,
			AbilityProficiencies = abProficiencies,
			SkillsProficiencies = skillProficiencies,
			Speed = race.Speed,
			MaxHits = hits,
			Hits = hits,

		});
		ContentManager.SaveCharacters();
        await Navigation.PopAsync();
	}
}