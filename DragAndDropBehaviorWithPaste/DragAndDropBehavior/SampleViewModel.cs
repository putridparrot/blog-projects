using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace DragAndDropBehavior
{
    public class SampleViewModel : IDropTarget
    {
        public SampleViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        bool IDropTarget.CanAccept(object source, IDataObject data)
        {
            return data?.GetData(DataFormats.CommaSeparatedValue) != null;
        }

        void IDropTarget.Drop(object source, IDataObject data)
        {
            // do something with the dropped data in our view model
            var s = data?.GetData(DataFormats.CommaSeparatedValue) as string;
            if (s != null)
            {
                var split = s.Split(new [] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in split)
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        Items.Add(item);
                    }
                }
            }
        }

        public ObservableCollection<string> Items { get; private set; }
    }
}
