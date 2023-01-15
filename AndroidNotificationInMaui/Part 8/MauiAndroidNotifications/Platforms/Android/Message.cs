using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAndroidNotifications.Platforms.Android;

public class Message
{
    public Message(string text, string sender)
    {
        Text = text;
        Sender = sender;
        // The Timestamp is required for the NotificationCompat.MessagingStyle.Message object, so we'll just generate here
        Timestamp = DateTime.Now.Millisecond; // prob. doesn't do the same as the Java example, need to check System.currentTimeMillis()
    }

    public string Text { get; }
    public long Timestamp { get; }
    public string Sender { get; }
}
