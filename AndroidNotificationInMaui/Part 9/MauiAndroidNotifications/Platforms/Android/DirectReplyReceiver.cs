using Android.Content;
using Android.Widget;
using AndroidX.Core.App;
using MauiAndroidNotifications.Platforms.Android;

namespace MauiAndroidNotifications;

// https://learn.microsoft.com/en-us/xamarin/android/app-fundamentals/broadcast-receivers
[BroadcastReceiver(Enabled = true, Exported = false)]
public class DirectReplyReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        var remoteInput = RemoteInput.GetResultsFromIntent(intent);
        if (remoteInput != null)
        {
            var replyText = remoteInput.GetCharSequence("key_text_reply");
            var answer = new Message(replyText, null);
            MainActivity.Messages.Add(answer);

            // without calling this the message will get added to the Messages but left in limbo
            // the reply will look like it's stuck sending a message (i.e. spinning progress bar and no updates)
            MainActivity.SendOnChannel1(context);
        }
    }
}