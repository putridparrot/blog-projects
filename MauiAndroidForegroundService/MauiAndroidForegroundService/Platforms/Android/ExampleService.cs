using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;

namespace MauiAndroidForegroundService.Platforms.Android;

[Service]
internal class ExampleService : Service
{
    public override IBinder OnBind(Intent intent)
    {
        return null;
    }

    public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
    {
        var input = intent.GetStringExtra("inputExtra");

        var notificationIntent = new Intent(this, typeof(MainActivity));
        var pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent, 0);

        var notification = new NotificationCompat.Builder(this, MainApplication.ChannelId)
            .SetContentTitle("Example Service")
            .SetContentText(input)
            .SetSmallIcon(Resource.Drawable.AppIcon)
            .SetContentIntent(pendingIntent)
            .Build();

        // if we do not StartForeground we can still see the service using the following but it'll be a background and will get shutdown
        // Settings | Developer Options | Running Services

        // Don't forget for Foreground service need to update AndroidManifest.xml with <uses-permission android:name="android.permission.FOREGROUND_SERVICE"/>
        StartForeground(1, notification);

        // This does not start on it's own thread, so be careful if running a long running service
        // on a UI thread and instead fire up a background task

        // We can stop the service from within using
        // StopSelf();

        return StartCommandResult.NotSticky;
    }
}