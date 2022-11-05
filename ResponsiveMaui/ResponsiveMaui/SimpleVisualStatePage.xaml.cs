namespace ResponsiveMaui;

public partial class SimpleVisualStatePage : ContentPage
{
	public SimpleVisualStatePage()
	{
		InitializeComponent();
        SizeChanged += OnSizeChanged;
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        VisualStateManager.GoToState(MainLabel, Width > 400 ? "Large" : "Default");
    }
}