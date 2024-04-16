namespace DiplomAttempt2;
using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

public partial class RacePage : ContentPage
{
    Race _race;
	public RacePage(Race race)
	{
		InitializeComponent();
		_race = race;
		Title = race.Name;
		Name.Text = race.Name;
		Description.Text = race.Description;
		StrengthEntry.Text = race.AbilityBonuses[0].ToString();
        DexterityEntry.Text = race.AbilityBonuses[1].ToString();
        ConstitutionEntry.Text = race.AbilityBonuses[2].ToString();
        WisdomEntry.Text = race.AbilityBonuses[3].ToString();
        IntelligenceEntry.Text = race.AbilityBonuses[4].ToString();
        CharismaEntry.Text = race.AbilityBonuses[5].ToString();
        SpellsList.ItemsSource = race.Spells;
        TraitsList.ItemsSource = race.Traits;
    }
    private void OnAddSpellButtonClicked(object sender, EventArgs e)
    {
        List<Spell> availableSpells = new List<Spell>();
        foreach(Package item in App.Packages)
        {
            availableSpells = availableSpells.Concat(item.Spells).ToList();
        }
        // �������� � ��������� Picker ��� ������ ����������
        Picker spellPicker = new Picker
        {
            Title = "Select Spell",
            ItemsSource = availableSpells
        };
        Button backButton = new Button() { Text = "�����" };
        backButton.Clicked += (s, e) =>
        {
            Content = baseContent;
        };
        // ���������� ������ ����������
        spellPicker.SelectedIndexChanged += (picker, args) =>
        {
            if (spellPicker.SelectedIndex != -1)
            {
                _race.Spells.Add(availableSpells[spellPicker.SelectedIndex]);
                Content = baseContent;
            }
        };
        Content = new StackLayout()
        {
            Children = {spellPicker,
                backButton
            }
        };
    }
    private void OnAddTraitButtonClicked(object sender, EventArgs e)
    {
        Entry titleEntry = new Entry() { Placeholder = "���������" };
        Entry traitEntry = new Entry() { Placeholder = "�����" };
        Button addButton = new Button() { Text = "��������" };
        Button backButton = new Button() { Text = "�����" };
        addButton.Clicked += (s, e) =>
        {
            _race.Traits.Add(new Trait() { Title = titleEntry.Text, Description = traitEntry.Text });
            Content = baseContent;
        };
        backButton.Clicked += (s, e) =>
        {
            Content = baseContent;
        };
        Content = new StackLayout()
        {
            Children = {titleEntry,
            traitEntry,
            addButton,
            backButton
            }
        };
    }
    private void SaveRace(object sender, EventArgs e)
    {
		_race.Name =  Name.Text;
		_race.Description = Description.Text;
        _race.AbilityBonuses[0]= Int32.Parse(StrengthEntry.Text);
        _race.AbilityBonuses[1] = Int32.Parse(DexterityEntry.Text);
        _race.AbilityBonuses[2] = Int32.Parse(ConstitutionEntry.Text);
        _race.AbilityBonuses[3] = Int32.Parse(WisdomEntry.Text);
        _race.AbilityBonuses[4] = Int32.Parse(IntelligenceEntry.Text);
        _race.AbilityBonuses[5] = Int32.Parse(CharismaEntry.Text);
        App.SavePackages();
    }
}