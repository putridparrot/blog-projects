namespace ResponsiveMaui.Extensions;

public static class ViewExtensions
{
    public static Page GetParentPage(this VisualElement element)
    {
        if (element != null)
        {
            var parent = element.Parent;
            while (parent != null)
            {
                if (parent is Page parentPage)
                {
                    return parentPage;
                }
                parent = parent.Parent;
            }
        }
        return null;
    }
}