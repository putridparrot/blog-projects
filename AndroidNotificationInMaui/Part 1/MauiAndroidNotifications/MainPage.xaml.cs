using CommunityToolkit.Mvvm.Messaging;

namespace MauiAndroidNotifications;

public partial class MainPage : ContentPage
{
    private readonly IMessenger _messenger;

    public MainPage(IMessenger messenger)
	{
		InitializeComponent();

        _messenger = messenger;
    }

    private void Channel1_OnClicked(object sender, EventArgs e)
    {
        _messenger.Send(new MessageData(1, Title.Text, Message.Text));
    }

    private void Channel2_OnClicked(object sender, EventArgs e)
    {
        _messenger.Send(new MessageData(2, Title.Text, Message.Text));
    }

}

