using DiplomAttempt2.Models;
using System.Collections.ObjectModel;

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
}