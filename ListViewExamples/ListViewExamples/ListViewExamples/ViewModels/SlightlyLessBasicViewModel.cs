using System;
using System.Collections.Generic;
using System.Text;
using Presentation.Core;
using Presentation.Core.Attributes;

namespace ListViewExamples.ViewModels
{
    public class SlightlyLessBasicItemViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Key} : {Value}";
        }
    }

    public class SlightlyLessBasicViewModel : ViewModel
    {
        public SlightlyLessBasicViewModel()
        {
            Items.AddRange(new []
            {
                new SlightlyLessBasicItemViewModel { Key = "Scooby", Value = "Doo" },
                new SlightlyLessBasicItemViewModel { Key = "Captain", Value = "Caveman" },
                new SlightlyLessBasicItemViewModel { Key = "Danger", Value = "Mouse" }
            });
        }

        [CreateInstance]
        public ExtendedObservableCollection<SlightlyLessBasicItemViewModel> Items
            => GetProperty<ExtendedObservableCollection<SlightlyLessBasicItemViewModel>>();
    }
}
