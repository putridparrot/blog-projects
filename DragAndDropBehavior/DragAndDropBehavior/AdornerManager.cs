using System;
using System.Windows;
using System.Windows.Documents;

namespace DragAndDropBehavior
{
    public class AdornerManager
    {
        private readonly AdornerLayer adornerLayer;
        private readonly Func<UIElement, Adorner> adornerFactory;

        private Adorner adorner;

        public AdornerManager(
                  AdornerLayer adornerLayer,
                  Func<UIElement, Adorner> adornerFactory)
        {
            this.adornerLayer = adornerLayer;
            this.adornerFactory = adornerFactory;
        }

        public void Update(UIElement adornedElement)
        {
            if (adorner == null || !adorner.AdornedElement.Equals(adornedElement))
            {
                Remove();
                adorner = adornerFactory(adornedElement);
                adornerLayer.Add(adorner);
                adornerLayer.Update(adornedElement);
                adorner.Visibility = Visibility.Visible;
            }
        }

        public void Remove()
        {
            if (adorner != null)
            {
                adorner.Visibility = Visibility.Collapsed;
                adornerLayer.Remove(adorner);
                adorner = null;
            }
        }
    }
}
