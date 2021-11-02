using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace BiometricTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (await CrossFingerprint.Current.IsAvailableAsync(true))
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync(
                    new AuthenticationRequestConfiguration("Login", "Access your account"));
                if (result.Authenticated)
                {
                    await DisplayAlert("Success", "Authenticated", "OK");
                }
                else
                {
                    await DisplayAlert("Failure", "Not Authenticated", "OK");
                }
            }
            else
            {
                await DisplayAlert("Failure", "Biometrics not available", "OK");
            }
        }
    }
}
