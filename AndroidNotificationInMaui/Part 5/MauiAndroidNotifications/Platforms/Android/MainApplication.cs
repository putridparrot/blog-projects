using Android.App;
using Android.OS;
using Android.Runtime;

namespace MauiAndroidNotifications;

[Application]
public class MainApplication : MauiApplication
{
    public const string Channel1Id = "channel1";
    public const string Channel2Id = "channel2";

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
            var channel1 = new NotificationChannel(Channel1Id, "Channel 1", NotificationImportance.High);
            channel1.Description = "This is Channel 1";

            var channel2 = new NotificationChannel(Channel2Id, "Channel 2", NotificationImportance.Low);
            channel2.Description = "This is Channel 2";

            if (GetSystemService(NotificationService) is NotificationManager manager)
            {
                manager.CreateNotificationChannel(channel1);
                manager.CreateNotificationChannel(channel2);
            }
#pragma warning restore CA1416
        }
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
