using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveMaui.Extensions;

public static class OrientationLayout
{
    public static readonly BindableProperty OrientationTemplateSelectorProperty = BindableProperty.CreateAttached("OrientationTemplateSelector",
        typeof(DataTemplateSelector), typeof(OrientationLayout), default(DataTemplateSelector), propertyChanged: Invalidate);

    // need some way to get the orientation data

    private static void Invalidate(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Layout layout)
        {
            var dataTemplate = GetOrientationTemplateSelector(bindable);
            var selected = dataTemplate.SelectTemplate("Portrait", layout);
            layout.Children.Clear();
            layout.Children.Add(CreateItemView("Portrait", selected));
        }
    }

    public static DataTemplateSelector GetOrientationTemplateSelector(BindableObject bindable)
    {
        return (DataTemplateSelector)bindable.GetValue(OrientationTemplateSelectorProperty);
    }

    public static void SetOrientationTemplateSelector(BindableObject bindable, DataTemplateSelector value)
    {
        bindable.SetValue(OrientationTemplateSelectorProperty, value);
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

}