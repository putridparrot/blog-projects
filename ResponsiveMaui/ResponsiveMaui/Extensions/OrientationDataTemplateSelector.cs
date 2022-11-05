using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveMaui.Extensions;

public class OrientationDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate Landscape { get; set; }
    public DataTemplate Portrait { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        return item?.ToString() == "Portrait" ? Portrait : Landscape;
    } 
}