using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DiplomAttempt2;

public partial class FeatsPage : ContentPage
{
    ObservableCollection<Feat> _feats;

    public FeatsPage(ObservableCollection<Feat> feats)
	{
		InitializeComponent();
        _feats = feats;
        FeatsView.ItemsSource = feats;
    }

    private async void CreateClicked(object sender, EventArgs e)
    {
        string name = await DisplayPromptAsync("Новая черта", "Введите название:");
        if (!String.IsNullOrWhiteSpace(name))
        {
            Feat feat = new Feat() { Name = name };
            _feats.Add(feat);
            App.SavePackages();
        }
    }
}