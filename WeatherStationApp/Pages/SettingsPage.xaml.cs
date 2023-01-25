using WeatherStationApp.ViewModels;

namespace WeatherStationApp.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsVM settingsVM)
	{
		BindingContext = settingsVM;
		InitializeComponent();
	}
}