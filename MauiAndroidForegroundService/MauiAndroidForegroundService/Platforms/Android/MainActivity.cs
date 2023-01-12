using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.Content;
using CommunityToolkit.Mvvm.Messaging;
using MauiAndroidForegroundService.Platforms.Android;
using static Android.Renderscripts.ScriptGroup;

namespace MauiAndroidForegroundService;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public MainActivity()
    {
        var messenger = MauiApplication.Current.Services.GetService<IMessenger>();
        messenger.Register<MessageData>(this, (recipient, message) =>
        {
            if (message.Start)
            {
                StartService(message.Message);
            }
            else
            {
                StopService();
            }
        });
    }

    private void StartService(string input)
    {
        var serviceIntent = new Intent(this, typeof(ExampleService));
        serviceIntent.PutExtra("inputExtra", input);

        // this work whilst app is in the foreground
        StartService(serviceIntent);
        // if we want to start from an app in the background use the following as this will 
        // promote to foreground, you have 5 seconds to start the service i.e. within ExampleService.OnStartCommand
        // StartForegroundService(serviceIntent);
        // OR
        // Use the convenience method below which handles version compat
        // ContextCompat.StartForegroundService(this, serviceIntent);
    }

    private void StopService()
    {
        var serviceIntent = new Intent(this, typeof(ExampleService));
        StopService(serviceIntent);
    }
}
