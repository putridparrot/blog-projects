using Android.Content;
using Android.Widget;

namespace MauiAndroidNotifications;

// https://learn.microsoft.com/en-us/xamarin/android/app-fundamentals/broadcast-receivers
[BroadcastReceiver(Enabled = true, Exported = false)]
public class NotificationReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        var message = intent.GetStringExtra(MainApplication.ToastMessage);
        Toast.MakeText(context, message, ToastLength.Short).Show();
    }
}