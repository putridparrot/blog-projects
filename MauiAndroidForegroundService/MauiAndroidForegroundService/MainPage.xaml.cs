using CommunityToolkit.Mvvm.Messaging;

namespace MauiAndroidForegroundService;

public partial class MainPage : ContentPage
{
    private readonly IMessenger _messenger;

    public MainPage(IMessenger messenger)
	{
		InitializeComponent();

        _messenger = messenger;
    }

    private void Start_OnClicked(object sender, EventArgs e)
    {
        _messenger.Send(new MessageData(Input.Text, true));
    }

    private void Stop_OnClicked(object sender, EventArgs e)
    {
        _messenger.Send(new MessageData(Input.Text, false));
    }
}

