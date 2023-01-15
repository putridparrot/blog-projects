using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Support.V4.Media.Session;
using AndroidX.Annotations;
using AndroidX.Core.App;
using CommunityToolkit.Mvvm.Messaging;
using RemoteInput = AndroidX.Core.App.RemoteInput;
using Message = MauiAndroidNotifications.Platforms.Android.Message;
using Uri = Android.Net.Uri;

namespace MauiAndroidNotifications;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private readonly BroadcastReceiver _receiver;

    // As noted in the video part 5, ths is not great practise but just makes this demo simpler
    public static List<Message> Messages = new List<Message>();

    private NotificationManagerCompat _notificationManager;
    private readonly IMessenger _messenger;
    public MainActivity()
    {
        _receiver = new DirectReplyReceiver();

        _messenger = MauiApplication.Current.Services.GetService<IMessenger>();

        _messenger.Register<MessageData>(this, (recipient, message) =>
        {
            if (message.Channel == 1)
            {
                // channel 1
                SendOnChannel1(this);
            }
            else
            {
                // channel 2
                SendOnChannel2();
            }
        });

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
    // way to do in a production app (like creating a NotificationHelper
    public static void SendOnChannel1(Context context)
    {
        var notificationManager = NotificationManagerCompat.From(context);

        if (!notificationManager.AreNotificationsEnabled())
        {
            OpenNotificationSettings(context);
            return;
        }

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O && IsChannelBlocked(context, MainApplication.Channel1Id))
        {
            OpenChannelSettings(context, MainApplication.Channel1Id);
            return;
        }

        var activityIntent = new Intent(context, typeof(MainActivity));
        var contentIntent = PendingIntent.GetActivity(context, 0, activityIntent, 0);

        var remoteInput = new RemoteInput.Builder("key_text_reply")
            .SetLabel("Your answer...")
            .Build();

        Intent replyIntent = null;
        PendingIntent replyPendingIntent = null;

        if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
        {
            replyIntent = new Intent(context, typeof(DirectReplyReceiver));
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
            // only sho/update first time
            .SetOnlyAlertOnce(true)
            .Build();

        notificationManager.Notify(1, notification);
    }

    private void SendOnChannel2()
    {
        var notification1 = new NotificationCompat.Builder(this, MainApplication.Channel2Id)
            .SetSmallIcon(Resource.Drawable.abc_btn_check_material)
            .SetContentTitle("Title 1")
            .SetContentText("Message 1")
            .SetPriority(NotificationCompat.PriorityLow)
            .SetGroup("example_group")
            .Build();

        var notification2 = new NotificationCompat.Builder(this, MainApplication.Channel2Id)
            .SetSmallIcon(Resource.Drawable.abc_btn_check_material)
            .SetContentTitle("Title 2")
            .SetContentText("Message 2")
            .SetPriority(NotificationCompat.PriorityLow)
            .SetGroup("example_group")
            .Build();

        var summaryNotification = new NotificationCompat.Builder(this, MainApplication.Channel2Id)
            .SetSmallIcon(Resource.Drawable.abc_btn_colored_material)
            .SetStyle(new NotificationCompat.InboxStyle()
                .AddLine("Title 2 Message 2")
                .AddLine("Title 1 Message 1")
                .SetBigContentTitle("2 new messages")
                .SetSummaryText("user@example.com"))
            .SetPriority(NotificationCompat.PriorityLow)
            .SetGroup("example_group")
            .SetGroupAlertBehavior(NotificationCompat.GroupAlertChildren)
            .SetGroupSummary(true)
            .Build();


        Thread.Sleep(2000);
        _notificationManager.Notify(2, notification1);
        Thread.Sleep(2000);
        _notificationManager.Notify(3, notification2);
        Thread.Sleep(2000);
        _notificationManager.Notify(4, summaryNotification);
    }

    // in the video example this was not static but this is because I made the 
    // SendOnChannel1 method static for one of the other parts of the video to 
    // keep things simple
    private static void OpenNotificationSettings(Context context)
    {
        // api 26
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            var intent = new Intent(Settings.ActionAppNotificationSettings);
            intent.PutExtra(Settings.ExtraAppPackage, context.PackageName);
            context.StartActivity(intent);
        }
        else
        {
            var intent = new Intent(Settings.ActionApplicationDetailsSettings);
            intent.SetData(Uri.Parse($"package:{context.PackageName}"));
            context.StartActivity(intent);
        }
    }

    [RequiresApi(Api = 26)]
    private static bool IsChannelBlocked(Context context, string channelId)
    {
        if (context.GetSystemService(NotificationService) is NotificationManager manager)
        {
            var channel = manager.GetNotificationChannel(channelId);
            return channel is { Importance: NotificationImportance.None };
        }

        return false;
    }

    [RequiresApi(Api = 26)]
    private static void OpenChannelSettings(Context context, string channelId)
    {
        var intent = new Intent(Settings.ActionChannelNotificationSettings);
        intent.PutExtra(Settings.ExtraAppPackage, context.PackageName);
        intent.PutExtra(Settings.ExtraChannelId, channelId);
        context.StartActivity(intent);
    }
}