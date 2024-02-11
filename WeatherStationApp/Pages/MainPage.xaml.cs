using CommunityToolkit.Mvvm.Messaging;
using WeatherStationApp.Messages;
using WeatherStationApp.ViewModels;

namespace WeatherStationApp.Pages;

public partial class MainPage :
    ContentPage,
	IRecipient<ErrorMessage>
{
    private readonly MainPageVM _mainPageVM;

    public MainPage(MainPageVM mainPageVM)
	{
        BindingContext = mainPageVM;
        _mainPageVM = mainPageVM;
        InitializeComponent();

        WeakReferenceMessenger.Default.Register<ErrorMessage>(this);
    }

    protected override void OnAppearing()
    {
        _mainPageVM.LoadData();
    }

    public void Receive(ErrorMessage message)
    {
        DisplayAlert("Error!", message.Error, "OK");
    }
}