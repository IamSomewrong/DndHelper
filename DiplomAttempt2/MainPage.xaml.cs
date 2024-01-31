namespace DiplomAttempt2;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	public async void ToPlayerPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PlayerPage());
	}
}

