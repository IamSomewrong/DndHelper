namespace DiplomAttempt2;
using DiplomAttempt2.Models;
public partial class PackagePage : ContentPage
{
	Package _package;
	public PackagePage(Package package)
	{
		InitializeComponent();
		_package = package;
		Title = package.Name;
		ClassesList.Header = new HorizontalStackLayout
		{
			Children = {
				new Label { Text = "Классы:", FontSize = 18 },
				new Button { Text = "добавить", FontSize = 12 },
			}
		};
        ClassesList.ItemsSource = _package.Classes;

        RacesList.Header = new HorizontalStackLayout
        {
            Children = {
                new Label { Text = "Расы:", FontSize = 18 },
                new Button { Text = "добавить", FontSize = 12 },
            }
        };
        RacesList.ItemsSource = _package.Races;

        EnemiesList.Header = new HorizontalStackLayout
        {
            Children = {
                new Label { Text = "Бестиарий:", FontSize = 18 },
                new Button { Text = "добавить", FontSize = 12 },
            }
        };
        EnemiesList.ItemsSource = _package.Enemies;

        ItemsList.Header = new HorizontalStackLayout
        {
            Children = {
                new Label { Text = "Предметы:", FontSize = 18 },
                new Button { Text = "добавить", FontSize = 12 },
            }
        };
        ItemsList.ItemsSource = _package.Items;

        SpellsList.Header = new HorizontalStackLayout
        {
            Children = {
                new Label { Text = "Заклинания:", FontSize = 18 },
                new Button { Text = "добавить", FontSize = 12 },
            }
        };
        SpellsList.ItemsSource = _package.Spells;
    }


}