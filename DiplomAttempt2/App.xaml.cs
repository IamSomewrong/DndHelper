using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Xml.Linq;
namespace DiplomAttempt2;

public partial class App : Application
{
	public static ObservableCollection<Package> Packages;
    public static string[] _files = Directory.GetFiles(FileSystem.AppDataDirectory, "*.pckg");
    public static ObservableCollection<Character> Characters;
    static string charFile = FileSystem.AppDataDirectory + "/characters.json";

    public static void SavePackages()
    {
        foreach(Package package in Packages)
        {
            var writeData = JsonSerializer.Serialize(package);
            File.WriteAllText(FileSystem.AppDataDirectory + "/" + package.Name + ".pckg", writeData);
        }
    }
    public static void SaveCharacters()
    {
        var writeData = JsonSerializer.Serialize(Characters);
        File.WriteAllText(charFile, writeData);
    }
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
                Feats = new ObservableCollection<Feat>(),
                Origins = new ObservableCollection<Origin>(),
            };
            var writeData = JsonSerializer.Serialize(package);
            File.WriteAllText(FileSystem.AppDataDirectory + "/Базовый пакет.pckg", writeData);
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

        
        try
        {
            var data = File.ReadAllText(charFile);
            Characters = JsonSerializer.Deserialize<ObservableCollection<Character>>(data);
        } 
        catch (Exception)
        {   
            Characters = new ObservableCollection<Character>();
            var data = JsonSerializer.Serialize(Characters);
            File.WriteAllText(charFile, data);
        }
        

        MainPage = new AppShell();
	}
}

