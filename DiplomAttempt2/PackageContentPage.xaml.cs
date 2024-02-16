using System.Collections.ObjectModel;
using System.Text.Json;
using DiplomAttempt2.Models;

namespace DiplomAttempt2;
public partial class PackageContentPage : ContentPage
{
    public PackageContentPage()
	{
		InitializeComponent();
        PackageView.ItemsSource = App.Packages.Packages;
    }

    public async void CreatePackage(object sender, EventArgs e)
    {
        var name = await DisplayPromptAsync("Новый пакет", "Введите название:");
        App.Packages.Packages.Add(new Package() { Name = name });
#if ANDROID
        string str = JsonSerializer.Serialize<SerializablePackages>(App.Packages);
        FileStream fs = new(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/packs.json", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        sw.Write(str);
        sw.Close();
        fs.Close();
#elif WINDOWS
        string str = JsonSerializer.Serialize<SerializablePackages>(App.Packages);
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\packs.json";
        FileStream fs = new(path, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        sw.Write(str);
        sw.Close();
        fs.Close();
#endif
    }
}