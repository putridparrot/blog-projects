using Microsoft.AspNetCore.Components;

namespace BlazorTemplates.Components;

public partial class ListView<TItem>
{
    [Parameter] public RenderFragment? HeaderTemplate { get; set; }
    [Parameter] public RenderFragment? FooterTemplate { get; set; }
    [Parameter] public RenderFragment<RenderFragment>? ListTemplate { get; set; }
    [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; } = default!;
    [Parameter] public IReadOnlyList<TItem> Items { get; set; } = default!;
}