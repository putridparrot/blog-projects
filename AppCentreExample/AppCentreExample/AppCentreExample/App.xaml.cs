using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AppCentreExample
{
	public partial class App : Application
	{
	    private const string ANDROID_KEY = "";
	    private const string UWP_KEY = "";
	    private const string IOS_KEY = "";

        public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
		    AppCenter.Start($"android={ANDROID_KEY};" +
                            $"uwp={UWP_KEY};" +
		                    $"ios={IOS_KEY}",
		        typeof(Analytics), 
                typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
