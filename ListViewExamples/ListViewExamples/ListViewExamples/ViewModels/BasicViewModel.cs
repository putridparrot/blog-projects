using System.ComponentModel;
using Presentation.Core;
using Presentation.Core.Attributes;

namespace ListViewExamples.ViewModels
{
    public class BasicViewModel : ViewModel
    {
        [CreateInstance]
        [DefaultValue(new[] { "GET", "POST", "HEAD", "DELETE" })]
        public ExtendedObservableCollection<string> Items
            => GetProperty<ExtendedObservableCollection<string>>();
    }
}
