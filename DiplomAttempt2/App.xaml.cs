using System.Collections.ObjectModel;
using System.Text.Json;
using System.Xml.Linq;
namespace DiplomAttempt2;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();
        ContentManager.LoadData();
        MainPage = new AppShell();
	}
}

