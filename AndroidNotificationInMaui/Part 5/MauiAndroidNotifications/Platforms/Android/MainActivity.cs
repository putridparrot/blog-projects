using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Media.Session;
using AndroidX.Core.App;
using CommunityToolkit.Mvvm.Messaging;
using RemoteInput = AndroidX.Core.App.RemoteInput;
using Message = MauiAndroidNotifications.Platforms.Android.Message;

namespace MauiAndroidNotifications;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private readonly BroadcastReceiver _receiver;
    private readonly MediaSessionCompat _mediaSession;

    // As noted in the video part 5, ths is not great practise but just makes this demo simpler
    public static List<Message> Messages = new List<Message>();

    private NotificationManagerCompat _notificationManager;
    public MainActivity()
    {
        _receiver = new DirectReplyReceiver();

        var messenger = MauiApplication.Current.Services.GetService<IMessenger>();

        messenger.Register<MessageData>(this, (recipient, message) =>
        {
            if (message.Channel == 1)
            {
                SendOnChannel1(this);
            }
            else
            {
                SendOnChannel2(message.Title, message.Message);
            }
        });

        // This seems to cause JNI failure
        // _mediaSession = new MediaSessionCompat(this, "tag");

        Messages.Add(new Message("Good morning!", "Jim"));
        Messages.Add(new Message("Hello", null)); // null will be from us, and hence will use the "Me" from the messaging style
        Messages.Add(new Message("Ji!", "Jenny"));
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        _notificationManager = NotificationManagerCompat.From(this);
    }

    // These changes (inc. static) are just just for ease of the demo, should think about a better
    // way to do in a production app (like creating a NotificationHelper)
    public static void SendOnChannel1(Context context)
    {
        var activityIntent = new Intent(context, typeof(MainActivity));
        var contentIntent = PendingIntent.GetActivity(context, 0, activityIntent, 0);

        var remoteInput = new RemoteInput.Builder("key_text_reply")
            .SetLabel("Your answer...")
            .Build();

        PendingIntent replyPendingIntent = null;

        if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
        {
            var replyIntent = new Intent(context, typeof(DirectReplyReceiver));
            replyPendingIntent = PendingIntent.GetBroadcast(context, 0, replyIntent, 0);
        }
        else
        {
            // older versions of Android 
            // start activity instead PendingIntent.GetActivity()
            // cancel notification with notificationManagerCompat.Cancel(id)
        }

        var replyAction = new NotificationCompat.Action.Builder(Resource.Drawable.AppIcon, "Reply", replyPendingIntent)
            .AddRemoteInput(remoteInput)
            .Build();

        var messagingStyle = new NotificationCompat.MessagingStyle("Me");
        messagingStyle.SetConversationTitle("Group Chat");

        foreach(var chatMessage in Messages)
        {
            var notificationMessage =
                new NotificationCompat.MessagingStyle.Message(chatMessage.Text, chatMessage.Timestamp,
                    chatMessage.Sender);
            messagingStyle.AddMessage(notificationMessage);
        }

        var notification = new NotificationCompat.Builder(context, MainApplication.Channel1Id)
            // mandatory
            .SetSmallIcon(Resource.Drawable.abc_ab_share_pack_mtrl_alpha)
            .SetStyle(messagingStyle)
            .AddAction(replyAction)
            .SetColor(Colors.Blue.ToInt())
            .SetPriority(NotificationCompat.PriorityHigh)
            .SetCategory(NotificationCompat.CategoryMessage)
            .SetContentIntent(contentIntent)
            // when we tap the notification it will close
            .SetAutoCancel(true)
            // only show/update first time
            .SetOnlyAlertOnce(true)
            .Build();

        var notificationManager = NotificationManagerCompat.From(context);
        notificationManager.Notify(1, notification);
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