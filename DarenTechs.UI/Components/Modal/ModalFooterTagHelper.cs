using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace DarenTechs.UI.Components.Modal
{
    public class ModalFooterTagHelper : TagHelper
    {
        public ModalFooter ModalFooterButtons { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = CreateFooter();
            output.Attributes.SetAttribute("class", "modal-footer");
            output.Content.SetHtmlContent(content);
            output.TagName = "div";
        }

        private string CreateFooter()
        {
            StringBuilder sb = new StringBuilder("<button data-dismiss='modal' ");
            sb.Append("id='");
            sb.Append(ModalFooterButtons.CancelButtonID);
            sb.Append("' class='btn btn-default' type='button'>");
            sb.Append(ModalFooterButtons.CancelButtonText);
            sb.Append("</button>");

            if (!ModalFooterButtons.OnlyCancelButton)
            {
                sb.Append("<button class='btn btn-success' ");
                sb.Append("id='");
                sb.Append(ModalFooterButtons.SaveButtonID);
                if (ModalFooterButtons.SaveButtonType == SaveButtonTypeModel.Submit)
                {
                    sb.Append("' type='submit'");
                }
                else if (ModalFooterButtons.SaveButtonType == SaveButtonTypeModel.Button)
                {
                    sb.Append("' type='button'");
                }
                else
                {
                    sb.Append("'");
                }
                
                sb.Append(">");
                sb.Append(ModalFooterButtons.SaveButtonText);
                sb.Append("</button>");
            }

            return sb.ToString();
        }
    }
}
