using System;
using System.Windows.Input;
using Presentation.Core;
using Presentation.Core.Attributes;

namespace ListViewExamples.ViewModels
{
    public class PullToRefereshViewModel : ViewModel
    {
        public PullToRefereshViewModel()
        {
            RefreshCommand = new ActionCommand(() =>
            {
                Items.Add(DateTime.Now.ToString());
                IsRefreshing = false;
            }, () => true); 
        }

        [CreateInstance]
        public ExtendedObservableCollection<string> Items
            => GetProperty<ExtendedObservableCollection<string>>();

        public ICommand RefreshCommand { get; }

        public bool IsRefreshing
        {
            get => GetProperty<bool>();
            set => SetProperty(value);
        }
    }
}
