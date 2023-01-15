using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiAndroidNotifications;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private NotificationManagerCompat _notificationManager;

    public MainActivity()
    {
        var messenger = MauiApplication.Current.Services.GetService<IMessenger>();

        messenger.Register<MessageData>(this, (recipient, message) =>
        {
            if (message.Channel == 1)
            {
                // channel 1
                SendOnChannel1(message.Title, message.Message);
            }
            else
            {
                // channel 2
                SendOnChannel2(message.Title, message.Message);
            }
        });
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        _notificationManager = NotificationManagerCompat.From(this);
    }

    private void SendOnChannel1(string title, string message)
    {
        var notification = new NotificationCompat.Builder(this, MainApplication.Channel1Id)
            .SetSmallIcon(Resource.Drawable.abc_ab_share_pack_mtrl_alpha)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetPriority(NotificationCompat.PriorityHigh)
            .SetCategory(NotificationCompat.CategoryMessage)
            .Build();

        _notificationManager.Notify(1, notification);
    }

    private void SendOnChannel2(string title, string message)
    {
        var notification = new NotificationCompat.Builder(this, MainApplication.Channel2Id)
            .SetSmallIcon(Resource.Drawable.abc_btn_check_material)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetPriority(NotificationCompat.PriorityLow)
            .Build();

        _notificationManager.Notify(2, notification);
    }
}
