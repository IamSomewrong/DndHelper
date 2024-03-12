using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
namespace DiplomAttempt2;

public partial class App : Application
{
	public static ObservableCollection<Package> Packages;
    public static string[] _files = Directory.GetFiles(FileSystem.AppDataDirectory, "*.pckg");
    public App()
	{
		InitializeComponent();
        Packages = new ObservableCollection<Package>();
        if (_files.Length == 0)
        {
            Package package = new Package()
            {
                Name = "Базовый пакет",
                Classes = new ObservableCollection<Class>(),
                Races = new ObservableCollection<Race>(),
                Items = new ObservableCollection<Item>(),
                Enemies = new ObservableCollection<Enemy>(),
                Spells = new ObservableCollection<Spell>(),
            };
            var writeData = JsonSerializer.Serialize(package);
            File.WriteAllText(FileSystem.AppDataDirectory + "/base.pckg", writeData);
            Packages.Add(package);
        }
        else
        {
            foreach(var file in _files)
            {
                var rawData = File.ReadAllText(file);
                Package package = JsonSerializer.Deserialize<Package>(rawData);
                Packages.Add(package);
            }
        }

        MainPage = new AppShell();
	}
}

