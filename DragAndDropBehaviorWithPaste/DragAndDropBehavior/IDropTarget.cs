using System.Windows;

namespace DragAndDropBehavior
{
    public interface IDropTarget
    {
        bool CanAccept(object source, IDataObject data);
        void Drop(object source, IDataObject data);
    }
}