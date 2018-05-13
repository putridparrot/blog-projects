using System;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;

namespace AppCentreExample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

	    private void NewFeature_OnClicked(object sender, EventArgs e)
	    {
            Analytics.TrackEvent("New Feature Used");
	    }

	    private void Exception_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException("This is an exception");
	    }
	}
}
