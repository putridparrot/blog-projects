using System;
using System.Windows.Input;
using Presentation.Core;
using Presentation.Core.Attributes;

namespace ListViewExamples.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly ContextMenuViewModel _parent;
        public ItemViewModel(ContextMenuViewModel parent, string value)
        {
            _parent = parent;
            Value = value;
            DeleteCommand = new ActionCommand<ItemViewModel>(s =>
            {
                _parent.Items.Remove(this);
            });
        }

        public ICommand DeleteCommand { get; }

        public string Value
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public override string ToString()
        {
            return Value;
        }        
    }

    public class ContextMenuViewModel : ViewModel
    {
        public ContextMenuViewModel()
        {
            RefreshCommand = new ActionCommand(() =>
            {
                Items.Add(new ItemViewModel(this, DateTime.Now.ToString()));
                IsRefreshing = false;
            });
        }

        [CreateInstance]
        public ExtendedObservableCollection<ItemViewModel> Items
            => GetProperty<ExtendedObservableCollection<ItemViewModel>>();

        public ICommand RefreshCommand { get; }

        public bool IsRefreshing
        {
            get => GetProperty<bool>();
            set => SetProperty(value);
        }
    }
}
