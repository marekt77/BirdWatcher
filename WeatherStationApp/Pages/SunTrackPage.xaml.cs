using WeatherStationApp.ViewModels;

namespace WeatherStationApp.Pages;

public partial class SunTrackPage : ContentPage
{
	public SunTrackPage(SunTrackVM sunTrackVM)
	{
        BindingContext = sunTrackVM;

        InitializeComponent();
    }
}