using System;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DragAndDropBehavior
{
    public class UIElementDropAdorner : Adorner
    {
        public UIElementDropAdorner(UIElement adornedElement) :
           base(adornedElement)
        {
            Focusable = false;
            IsHitTestVisible = false;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            const int PEN_WIDTH = 8;

            var adornedRect = new Rect(AdornedElement.RenderSize);

            drawingContext.DrawRectangle(Brushes.White,
                  new Pen(Brushes.LightGray, PEN_WIDTH),
                  adornedRect);

            var image = new BitmapImage(
                  new Uri("pack://application:,,,/DragAndDropBehavior;component/Resources/dropfolder.png",
                  UriKind.Absolute));

            var typeface = new Typeface(
                  new FontFamily("Segoe UI"),
                     FontStyles.Normal,
                     FontWeights.Normal, FontStretches.Normal);
            var formattedText = new FormattedText(
                  "Drop Items Here",
                  CultureInfo.CurrentUICulture,
                  FlowDirection.LeftToRight,
                  typeface,
                  24,
                  Brushes.LightGray);

            var centre = new Point(
                  AdornedElement.RenderSize.Width / 2,
                  AdornedElement.RenderSize.Height / 2);

            var top = centre.Y - (image.Height + formattedText.Height) / 2;
            var textLocation = new Point(
                  centre.X - formattedText.WidthIncludingTrailingWhitespace / 2,
                  top + image.Height);

            drawingContext.DrawImage(image,
                  new Rect(centre.X - image.Width / 2,
                  top,
                  image.Width,
                  image.Height));
            drawingContext.DrawText(formattedText, textLocation);
        }
    }
}
