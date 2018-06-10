using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewExamples.ViewModels;
using Xamarin.Forms;

namespace ListViewExamples
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void SlightlyLessBasic_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SlightlyLessBasicPage
            {
                BindingContext = new SlightlyLessBasicViewModel()
            });
        }

        private void Basic_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BasicPage
            {
                BindingContext = new BasicViewModel()
            });
        }

        private void Grouping_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GroupingPage
            {
                BindingContext = new GroupingViewModel()
            });
        }

        private void HeaderAndFooter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HeaderFooterPage
            {
                BindingContext = new GroupingViewModel()
            });
        }

        private void UnevenRows_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new UnevenRowsPage
            {
                BindingContext = new GroupingViewModel()
            });
        }

        private void PullToRefresh_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PullToRefreshPage
            {
                BindingContext = new PullToRefereshViewModel()
            });
        }

        private void ContextMenu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ContextMenuPage
            {
                BindingContext = new ContextMenuViewModel()
            });
        }
    }
}
