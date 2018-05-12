using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechsPlayArea.Web.TagHelpers
{
    [HtmlTargetElement(Attributes = nameof(IsVisible))]
    public class IsVisibleTagHelper : TagHelper
    {
        public bool IsVisible { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!IsVisible)
            {
                output.SuppressOutput();
            }
        }
    }
}
