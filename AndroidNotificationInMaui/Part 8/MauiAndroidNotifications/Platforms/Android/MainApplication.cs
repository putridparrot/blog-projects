using Android.App;
using Android.OS;
using Android.Runtime;

namespace MauiAndroidNotifications;

[Application]
public class MainApplication : MauiApplication
{
    public const string Group1Id = "group1";
    public const string Group2Id = "group2";
    public const string Channel1Id = "channel1";
    public const string Channel2Id = "channel2";
    public const string Channel3Id = "channel3";
    public const string Channel4Id = "channel4";

    public const string ToastMessage = "toastMessage";

    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

    public override void OnCreate()
    {
        base.OnCreate();

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
#pragma warning disable CA1416
            var group1 = new NotificationChannelGroup(Group1Id, "Group 1");

            var group2 = new NotificationChannelGroup(Group2Id, "Group 2");

            var channel1 = new NotificationChannel(Channel1Id, "Channel 1", NotificationImportance.High);
            channel1.Description = "This is Channel 1";
            channel1.Group = Group1Id;

            var channel2 = new NotificationChannel(Channel2Id, "Channel 2", NotificationImportance.Low);
            channel2.Description = "This is Channel 2";
            channel2.Group = Group1Id;

            var channel3 = new NotificationChannel(Channel3Id, "Channel 3", NotificationImportance.High);
            channel3.Description = "This is Channel 3";
            channel3.Group = Group2Id;

            var channel4 = new NotificationChannel(Channel4Id, "Channel 4", NotificationImportance.Low);
            channel4.Description = "This is Channel 4";
            // purposefully no group

            if (GetSystemService(NotificationService) is NotificationManager manager)
            {
                manager.CreateNotificationChannelGroup(group1);
                manager.CreateNotificationChannelGroup(group2);

                manager.CreateNotificationChannel(channel1);
                manager.CreateNotificationChannel(channel2);
                manager.CreateNotificationChannel(channel3);
                manager.CreateNotificationChannel(channel4);
            }
#pragma warning restore CA1416
        }
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
