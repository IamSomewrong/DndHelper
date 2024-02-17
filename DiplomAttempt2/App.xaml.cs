using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DiplomAttempt2;

public partial class App : Application
{
	public static SerializablePackages Packages;
    public static string _fileName = FileSystem.AppDataDirectory + "/packs.json";
    public App()
	{
		InitializeComponent();
        Packages = new SerializablePackages() { Packages = new ObservableCollection<Package>() };
        if (File.Exists(_fileName) == false)
        {
            var writeData = JsonSerializer.Serialize(Packages);
            File.WriteAllText(_fileName, writeData);
        }
        var rawData = File.ReadAllText(_fileName);
        Packages = JsonSerializer.Deserialize<SerializablePackages>(rawData);

        MainPage = new AppShell();
	}
}

