using CommunityToolkit.Mvvm.Messaging;
using WeatherStationApp.Messages;

namespace WeatherStationApp.Pages;

public partial class SettingsPage : 
	ContentPage,
    IRecipient<ConnectionCheckMessage>,
    IRecipient<SettingsSavedMessage>
{
	public SettingsPage()
	{
		InitializeComponent();

        WeakReferenceMessenger.Default.Register<ConnectionCheckMessage>(this);
        WeakReferenceMessenger.Default.Register<SettingsSavedMessage>(this);
    }

    public void Receive(ConnectionCheckMessage message)
    {
        if (message.IsSuccessful)
        {
            DisplayAlert("Success!", "We were able to connect to: " + message.ServerIPAddress, "OK");
        }
        else
        {
            DisplayAlert("Failed!", "We were not able to connect to: " + message.ServerIPAddress, "OK");
        }

    }

    public void Receive(SettingsSavedMessage message)
    {
        DisplayAlert("Success!", "Your settings have beend saved", "OK");
    }
}