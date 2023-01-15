using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Media.Session;
using AndroidX.Core.App;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiAndroidNotifications;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    // private readonly MediaSessionCompat _mediaSession;

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

        // This seems to cause JNI failure
        // _mediaSession = new MediaSessionCompat(this, "tag");
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

        var picture = BitmapFactory.DecodeResource(Android.App.Application.Context.Resources, Resource.Drawable.AppIcon);

        var notification = new NotificationCompat.Builder(this, MainApplication.Channel1Id)
            // mandatory
            .SetSmallIcon(Resource.Drawable.abc_ab_share_pack_mtrl_alpha)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetLargeIcon(picture)
            .SetStyle(new NotificationCompat
                    .BigPictureStyle()
                    .BigPicture(picture)
                    .BigLargeIcon(null))
            .SetPriority(NotificationCompat.PriorityHigh)
            .SetCategory(NotificationCompat.CategoryMessage)
            .SetContentIntent(contentIntent)
            // when we tap the notification it will close
            .SetAutoCancel(true)
            // only show/update first time
            .SetOnlyAlertOnce(true)
            .Build();

        _notificationManager.Notify(1, notification);
    }

    private void SendOnChannel2(string title, string message)
    {
        var artwork = BitmapFactory.DecodeResource(Android.App.Application.Context.Resources, Resource.Drawable.AppIcon);

        var notification = new NotificationCompat.Builder(this, MainApplication.Channel2Id)
            .SetSmallIcon(Resource.Drawable.abc_btn_check_material)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetLargeIcon(artwork)
            // can add 5 icons for media style
            .AddAction(Resource.Drawable.dislike, "Dislike", null)
            .AddAction(Resource.Drawable.previous, "Previous", null)
            .AddAction(Resource.Drawable.pause, "Pause", null)
            .AddAction(Resource.Drawable.next, "Next", null)
            .AddAction(Resource.Drawable.like, "Like", null)
            .SetStyle(new AndroidX.Media.App.NotificationCompat.MediaStyle()
                .SetShowActionsInCompactView(1, 2, 3) // the id's for the actions listed above
                /*.SetMediaSession(_mediaSession.SessionToken)*/) 
            .SetSubText("Sub Text")
            .SetPriority(NotificationCompat.PriorityLow)
            .Build();

        _notificationManager.Notify(2, notification);
    }
}