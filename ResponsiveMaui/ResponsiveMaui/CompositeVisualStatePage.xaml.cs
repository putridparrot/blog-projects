namespace ResponsiveMaui;

public partial class CompositeVisualStatePage : ContentPage
{
	public CompositeVisualStatePage()
	{
		InitializeComponent();
        SizeChanged += OnSizeChanged;
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        VisualStateManager.GoToState(this, Width > 400 ? "Large" : "Default");
    }
}