using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveMaui.Extensions;

public class BreakpointBehavior : Behavior<Page>
{
    protected override void OnAttachedTo(Page page)
    {
        page.SizeChanged += PageSizeChanged;
        base.OnAttachedTo(page);
    }

    protected override void OnDetachingFrom(Page page)
    {
        page.SizeChanged += PageSizeChanged;
        base.OnDetachingFrom(page);
    }

    private void PageSizeChanged(object sender, EventArgs e)
    {
        if (sender is Page page)
        {
            VisualStateManager.GoToState(page, ToState(page.Width));
        }
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