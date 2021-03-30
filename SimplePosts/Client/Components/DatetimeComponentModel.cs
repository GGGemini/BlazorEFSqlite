using Microsoft.AspNetCore.Components;
using System;

namespace SimplePosts.Client.Components
{
    public class DatetimeComponentModel : ComponentBase
    {
        [Parameter]
        public DateTime DateTime { get; set; }
    }
}
