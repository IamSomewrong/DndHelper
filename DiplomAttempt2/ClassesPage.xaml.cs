using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DiplomAttempt2;

public partial class ClassesPage : ContentPage
{
    ObservableCollection<Class> _classes;

    public ClassesPage(ObservableCollection<Class> classes)
    {
        InitializeComponent();
        _classes = classes;
        FeatsView.ItemsSource = classes;
    }

    private async void CreateClicked(object sender, EventArgs e)
    {
        string name = await DisplayPromptAsync("Создание класса", "Введите название:");
        if (!String.IsNullOrWhiteSpace(name))
        {
            Class myClass = new Class()
            {
                Name = name,
                SavingThrows = new ObservableCollection<Ability>(),
                Skills = new ObservableCollection<Skill>(),
                Armors = new ObservableCollection<Armor>(),
                Weapons = new ObservableCollection<Weapon>(),
                Tools = new ObservableCollection<Gear>(),
                ClassFeatures = new ObservableCollection<ClassFeature>(),
                Subclasses = new ObservableCollection<Subclass>()
            };
            _classes.Add(myClass);
            App.SavePackages();
        }
    }

    private async void ToClass(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new ClassPage(_classes[e.ItemIndex]));
    }
}
