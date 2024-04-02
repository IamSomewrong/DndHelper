namespace DiplomAttempt2;



public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	public async void ToPlayerPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PlayerPage());
	}

    public async void ToUserContentPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserContentPage());
    }


}

