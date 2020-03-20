using System;
using System.Globalization;
using MatTestMobile.Resources;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatTestMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var culture = CrossMultilingual.Current.DeviceCultureInfo;
            AppResources.Culture = culture;

            // replace the above with this to change to specific language resources
            //var culture = new CultureInfo("fr-FR");
            //AppResources.Culture = culture;
            //CrossMultilingual.Current.CurrentCultureInfo = culture;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
