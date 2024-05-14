namespace DiplomAttempt2;
using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

public partial class ClassPage : ContentPage
{
    Class _class;
	public ClassPage(Class myClass)
	{
		InitializeComponent();
		_class = myClass;
		Title = myClass.Name;
        Name.Text = myClass.Name;
        Description.Text = myClass.Description;
        SkillsCount.Text = myClass.SkillsCount.ToString();
        switch (myClass.HitDice)
        {
            case Dice.K4:
                Radio4.IsChecked = true;
                break;
            case Dice.K6:
                Radio6.IsChecked = true;
                break;
            case Dice.K8:
                Radio8.IsChecked = true;
                break;
            case Dice.K10:
                Radio10.IsChecked = true;
                break;
            case Dice.K12:
                Radio12.IsChecked = true;
                break;
            case Dice.K20:
                Radio20.IsChecked = true;
                break;
        }
        foreach (var item in _class.SavingThrows)
        {
            switch (item)
            {
                case Ability.Strength:
                    CheckStrength.IsChecked = true; 
                    break;
                case Ability.Dexterity:
                    CheckDexterity.IsChecked = true;
                    break;
                case Ability.Constitution:
                    CheckConstitution.IsChecked = true;
                    break;
                case Ability.Wisdom:
                    CheckWisdom.IsChecked = true;
                    break;
                case Ability.Intelligence:
                    CheckIntelligence.IsChecked = true;
                    break;
                case Ability.Charisma:
                    CheckCharisma.IsChecked = true;
                    break;
            }
        }
        SkillsList.ItemsSource = _class.Skills;
    }

    private void OnAddSkillButtonClicked(object sender, EventArgs e)
    {
        Picker skillPicker = new Picker() { ItemsSource = Enum.GetNames(typeof(Skill)),
                                            Title = "Способность"};
        Button addButton = new Button() { Text = "Добавить" };
        Button backButton = new Button() { Text = "Назад" };
        addButton.Clicked += (s, e) =>
        {
            _class.Skills.Add((Skill)Enum.GetValues(typeof(Skill)).GetValue(skillPicker.SelectedIndex));
            Content = baseContent;
        };
        backButton.Clicked += (s, e) =>
        {
            Content = baseContent;
        };
        Content = new StackLayout()
        {
            Children = {skillPicker,
            addButton,
            backButton
            }
        };
    }

    private void SaveClass(object sender, EventArgs e)
    {
        _class.Name = Name.Text;
        _class.Description = Description.Text;
        _class.SkillsCount = Int32.Parse(SkillsCount.Text);
        ObservableCollection<Ability> abilities = new ObservableCollection<Ability>();
        if (CheckStrength.IsChecked)
            abilities.Add(Ability.Strength);
        if (CheckDexterity.IsChecked)
            abilities.Add(Ability.Dexterity);
        if (CheckConstitution.IsChecked)
            abilities.Add(Ability.Constitution);
        if (CheckWisdom.IsChecked)
            abilities.Add(Ability.Wisdom);
        if (CheckIntelligence.IsChecked)
            abilities.Add(Ability.Intelligence);
        if (CheckCharisma.IsChecked)
            abilities.Add(Ability.Charisma);
        _class.SavingThrows = abilities;
        if (Radio4.IsChecked)
            _class.HitDice = Dice.K4;
        else if (Radio6.IsChecked)
            _class.HitDice = Dice.K6;
        else if (Radio8.IsChecked)
            _class.HitDice = Dice.K8;
        else if (Radio10.IsChecked)
            _class.HitDice = Dice.K10;
        else if (Radio12.IsChecked)
            _class.HitDice = Dice.K12;
        else if (Radio20.IsChecked)
            _class.HitDice = Dice.K20;
        ContentManager.SavePackages();
    }
}