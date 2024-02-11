using CommunityToolkit.Mvvm.Messaging;
using WeatherStationApp.Messages;
using WeatherStationApp.ViewModels;

namespace WeatherStationApp.Pages;

public partial class SunTrackPage : 
	ContentPage,
    IRecipient<ErrorMessage>
{
    private readonly SunTrackVM _sunTrackVM;
    public SunTrackPage(SunTrackVM sunTrackVM)
	{
        BindingContext = sunTrackVM;

        _sunTrackVM = sunTrackVM;

        InitializeComponent();

        WeakReferenceMessenger.Default.Register<ErrorMessage>(this);
    }
    protected override void OnAppearing()
    {
        _sunTrackVM.GetWeatherData();
    }

    public void Receive(ErrorMessage message)
    {
        DisplayAlert("Error", message.Error, "OK");
    }
}