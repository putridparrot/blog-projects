using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace DragAndDropBehavior
{
    public class UIElementDropBehavior : Behavior<UIElement>
    {
        private AdornerManager _adornerManager;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.AllowDrop = true;
            AssociatedObject.DragEnter += AssociatedObject_DragEnter;
            AssociatedObject.DragOver += AssociatedObject_DragOver;
            AssociatedObject.DragLeave += AssociatedObject_DragLeave;
            AssociatedObject.Drop += AssociatedObject_Drop;
            AssociatedObject.PreviewKeyDown += AssociatedObjectOnKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.AllowDrop = false;
            AssociatedObject.DragEnter -= AssociatedObject_DragEnter;
            AssociatedObject.DragOver -= AssociatedObject_DragOver;
            AssociatedObject.DragLeave -= AssociatedObject_DragLeave;
            AssociatedObject.Drop -= AssociatedObject_Drop;
            AssociatedObject.PreviewKeyDown -= AssociatedObjectOnKeyDown;
        }

        private void AssociatedObjectOnKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) ||
                (e.Key == Key.V) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                var data = Clipboard.GetDataObject();
                if (CanAccept(sender, data))
                {
                    Drop(sender, data);
                }
            }
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (CanAccept(sender, e.Data))
            {
                Drop(sender, e.Data);
            }

            if (_adornerManager != null)
            {
                _adornerManager.Remove();
            }
            e.Handled = true;
        }

        private void AssociatedObject_DragLeave(object sender, DragEventArgs e)
        {
            if (_adornerManager != null)
            {
                var inputElement = sender as IInputElement;
                if (inputElement != null)
                {
                    var pt = e.GetPosition(inputElement);

                    var element = sender as UIElement;
                    if (element != null)
                    {
                        if (!pt.Within(element.RenderSize) || e.KeyStates == DragDropKeyStates.None)
                        {
                            _adornerManager.Remove();
                        }
                    }
                }
            }
            e.Handled = true;
        }

        private void AssociatedObject_DragOver(object sender, DragEventArgs e)
        {
            if (CanAccept(sender, e.Data))
            {
                e.Effects = DragDropEffects.Copy;

                if (_adornerManager != null)
                {
                    var element = sender as UIElement;
                    if (element != null)
                    {
                        _adornerManager.Update(element);
                    }
                }
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            if (_adornerManager == null)
            {
                var element = sender as UIElement;
                if (element != null)
                {
                    _adornerManager = new AdornerManager(AdornerLayer.GetAdornerLayer(element), adornedElement => new UIElementDropAdorner(adornedElement));
                }
            }
            e.Handled = true;
        }

        private bool CanAccept(object sender, IDataObject data)
        {
            var element = sender as FrameworkElement;
            if (element != null && element.DataContext != null)
            {
                var dropTarget = element.DataContext as IDropTarget;
                if (dropTarget != null)
                {
                    if (dropTarget.CanAccept(data.GetData("DragSource"), data))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void Drop(object sender, IDataObject data)
        {
            var element = sender as FrameworkElement;
            if (element != null && element.DataContext != null)
            {
                var target = element.DataContext as IDropTarget;
                if (target != null)
                {
                    target.Drop(data.GetData("DragSource"), data);
                }
            }
        }
    }
}
