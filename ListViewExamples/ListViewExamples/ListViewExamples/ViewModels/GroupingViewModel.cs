using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Presentation.Core;
using Presentation.Core.Attributes;

namespace ListViewExamples.ViewModels
{
    public class GroupViewModel : ObservableCollection<SlightlyLessBasicItemViewModel>
    {
        public string GroupName { get; set; }
    }

    public class GroupingViewModel : ViewModel
    {
        public GroupingViewModel()
        {
            Items.AddRange(new[]
            {
                new GroupViewModel { GroupName = "Dog" },
                new GroupViewModel { GroupName = "Others" }
            });
            Items[0].Add(new SlightlyLessBasicItemViewModel { Key = "Scooby", Value = "Doo" });
            Items[1].Add(new SlightlyLessBasicItemViewModel { Key = "Captain", Value = "Caveman"});
            Items[1].Add(new SlightlyLessBasicItemViewModel { Key = "Danger", Value = "Mouse"});
            Items[1].Add(new SlightlyLessBasicItemViewModel { Key = "The Hobbit", Value = "Bilbo, Collum, Beom, Azog, Gandalf, Sauron, Frodo, Dwalin, Smaug, Thranduil, Bard, Gloin, Thorin, Elron, Balid" });
        }

        [CreateInstance]
        public ExtendedObservableCollection<GroupViewModel> Items
            => GetProperty<ExtendedObservableCollection<GroupViewModel>>();

    }
}
