namespace ResponsiveMaui.Extensions;

public class OnOrientation : ContentView
{
    public View Landscape { get; set; }
    public View Portrait { get; set; }
    public View Square { get; set; }

    private Page _parentPage;

    protected override void OnParentSet()
    {
        base.OnParentSet();

        _parentPage = this.GetParentPage();
        if (_parentPage != null)
        {
            _parentPage.SizeChanged += PageOnSizeChanged;
        }
    }

    private void PageOnSizeChanged(object sender, EventArgs eventArgs)
    {
        if (_parentPage.Width < _parentPage.Height)
        {
            Content = Portrait ?? Landscape ?? Square;
        }
        else if (_parentPage.Height < _parentPage.Width)
        {
            Content = Landscape ?? Portrait ?? Square;
        }
        else
        {
            Content = Square ?? Portrait ?? Landscape;
        }
    }
}