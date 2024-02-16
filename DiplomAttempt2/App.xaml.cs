using DiplomAttempt2.Models;
using System.Text.Json;

namespace DiplomAttempt2;

public partial class App : Application
{
	public static SerializablePackages Packages;
    public App()
	{
		InitializeComponent();
#if ANDROID
            try 
            {
                FileStream fs = new(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "packs.json", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
                Packages = JsonSerializer.Deserialize<SerializablePackages>(sr.ReadToEnd());
                sr.Close();
                fs.Close();
            }
            catch (JsonException) 
            {
                Packages = new SerializablePackages();
                Packages.Packages = new System.Collections.ObjectModel.ObservableCollection<Package>();
                Packages.Packages.Add(new Package() { Name = "Тестовый пакет" });
                string str = JsonSerializer.Serialize<SerializablePackages>(Packages);
                FileStream fs = new(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/packs.json", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                sw.Write(str);
                sw.Close();
                fs.Close();
            }
#elif WINDOWS
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\packs.json";
                FileStream fs = new(path, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
                Packages = JsonSerializer.Deserialize<SerializablePackages>(sr.ReadToEnd());
                sr.Close();
                fs.Close();
            }
            catch (JsonException) 
            {
                Packages = new SerializablePackages();
                Packages.Packages = new System.Collections.ObjectModel.ObservableCollection<Package>();
                Packages.Packages.Add(new Package() { Name = "Тестовый пакет" });
                string str = JsonSerializer.Serialize<SerializablePackages>(Packages);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\packs.json";
                FileStream fs = new(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                sw.Write(str);
                sw.Close();
                fs.Close();
            }
#endif
        MainPage = new AppShell();
	}
}

