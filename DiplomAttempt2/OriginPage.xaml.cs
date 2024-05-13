namespace DiplomAttempt2;
using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

public partial class OriginPage : ContentPage
{
    Origin _origin;
	public OriginPage(Origin origin)
	{
		InitializeComponent();
		_origin = origin;
		Title = origin.Name;
        Name.Text = origin.Name;
        Description.Text = origin.Description;
        SkillsList.ItemsSource = _origin.Skills;
        TraitsList.ItemsSource = _origin.Traits;
    }

    private void OnAddSkillButtonClicked(object sender, EventArgs e)
    {
        Picker skillPicker = new Picker() { ItemsSource = Enum.GetNames(typeof(Skill)),
                                            Title = "Способность:"};
        Button addButton = new Button() { Text = "Добавить" };
        Button backButton = new Button() { Text = "Назад" };
        addButton.Clicked += (s, e) =>
        {
            _origin.Skills.Add((Skill)Enum.GetValues(typeof(Skill)).GetValue(skillPicker.SelectedIndex));
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

    private void SaveOrigin(object sender, EventArgs e)
    {
        _origin.Name = Name.Text;
        _origin.Description = Description.Text;
        App.SavePackages();
    }

    private void OnAddTraitButtonClicked(object sender, EventArgs e)
    {
        Entry entry = new Entry() { Placeholder = "Описание черты" };
        Button addButton = new Button() { Text = "Добавить" };
        Button backButton = new Button() { Text = "Назад" };
        addButton.Clicked += (s, e) =>
        {
            _origin.Traits.Add(entry.Text);
            Content = baseContent;
        };
        backButton.Clicked += (s, e) =>
        {
            Content = baseContent;
        };
        Content = new StackLayout()
        {
            Children = 
            {
            entry,
            addButton,
            backButton
            }
        };
    }
}