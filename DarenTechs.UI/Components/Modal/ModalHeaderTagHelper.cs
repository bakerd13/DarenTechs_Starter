using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarenTechs.UI.Components.Modal
{
    public class ModalHeaderTagHelper : TagHelper
    {
        public string ModelHeading { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = CreateHeader();
            output.Attributes.SetAttribute("class", "modal-header");
            output.Content.SetHtmlContent(content);
            output.TagName = "div";
        }

        private string CreateHeader()
        {
            StringBuilder sb = new StringBuilder("<h4 class='modal-title'>");
            sb.Append(ModelHeading);
            sb.Append("</h4>");
            sb.Append("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            
            return sb.ToString();
        }
    }
}
