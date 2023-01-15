using Android.App;
using Android.Content;
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
                SendOnChannel1(message.Title, message.Message);
            }
            else
            {
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
        var activityIntent = new Intent(this, typeof(MainActivity));
        var contentIntent = PendingIntent.GetActivity(this, 0, activityIntent, 0);

        var broadcastIntent = new Intent(this, typeof(NotificationReceiver));
        broadcastIntent.PutExtra(MainApplication.ToastMessage, message);
        var actionIntent = PendingIntent.GetBroadcast(this, 0, broadcastIntent, PendingIntentFlags.UpdateCurrent);

        var notification = new NotificationCompat.Builder(this, MainApplication.Channel1Id)
            .SetSmallIcon(Resource.Drawable.abc_ab_share_pack_mtrl_alpha)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetPriority(NotificationCompat.PriorityHigh)
            .SetCategory(NotificationCompat.CategoryMessage)
            // set the fore colour for the button etc.
            .SetColor(Colors.Red.ToInt())
            .SetContentIntent(contentIntent)
            // when we tap the notification it will close
            .SetAutoCancel(true)
            // only show/update first time
            .SetOnlyAlertOnce(true)
            // can add upto three action buttons
            .AddAction(Resource.Drawable.abc_edit_text_material, "Toast", actionIntent)
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