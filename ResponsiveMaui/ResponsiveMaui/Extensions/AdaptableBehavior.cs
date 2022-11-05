namespace ResponsiveMaui.Extensions;

public class AdaptableBehavior : Behavior<ContentPage>
{
    public static readonly BindableProperty OrientationTemplateSelectorProperty = BindableProperty.Create(nameof(OrientationTemplateSelector),
        typeof(DataTemplateSelector), typeof(OrientationLayout));

    public DataTemplateSelector OrientationTemplateSelector
    {
        get => (DataTemplateSelector)GetValue(OrientationTemplateSelectorProperty);
        set => SetValue(OrientationTemplateSelectorProperty, value);
    }

    private static View CreateItemView(object item, DataTemplate dataTemplate)
    {
        if (dataTemplate != null)
        {
            var view = (View)dataTemplate.CreateContent();
            view.BindingContext = item;
            return view;
        }

        return new Label { Text = item?.ToString(), HorizontalTextAlignment = TextAlignment.Center };
    }


    protected override void OnAttachedTo(ContentPage page)
    {
        page.SizeChanged += PageSizeChanged;
        base.OnAttachedTo(page);
    }

    protected override void OnDetachingFrom(ContentPage page)
    {
        page.SizeChanged += PageSizeChanged;
        base.OnDetachingFrom(page);
    }

    private void PageSizeChanged(object sender, EventArgs e)
    {
        if (sender is ContentPage page)
        {
            var orientation = GetOrientation(page);
            var dataTemplate = OrientationTemplateSelector;
            var selected = dataTemplate.SelectTemplate(orientation, page);
            page.Content = CreateItemView(orientation, selected);

            VisualStateManager.GoToState(page.Content, ToState(page.Width));
        }
    }

    private string GetOrientation(Page page)
    {
        return page.Width > page.Height ? "Landscape" : "Portrait";
    }

    private string ToState(double width)
    {
        if (width >= 1400)
            return "ExtraExtraLarge";
        if (width >= 1200)
            return "ExtraLarge";
        if (width >= 992)
            return "Large";
        if (width >= 768)
            return "Medium";
        if (width >= 576)
            return "Small";

        return "ExtraSmall";
    }
}