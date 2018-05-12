using DarenTechs.Data.TreeData;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarenTechs.Blog.TagHelpers
{
    public class BlogNavigationTagHelper : TagHelper
    {
        public Tree TreeStructure { get; set; }

        public string TreeId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tree = new List<Tree>();
            tree.Add(TreeStructure);

            var content = new StringBuilder($"<div id='{TreeId}'>");

            var rootData = tree.Where(n => n.ParentId == string.Empty).FirstOrDefault();

            content.Append(CreateTree(tree, rootData));
            content.Append("</div>");

            output.Content.SetHtmlContent(content.ToString());
        }

        private string CreateTree(List<Tree> treeStructure, Tree rootData)
        {
            if (treeStructure == null || treeStructure.Count == 0)
                return String.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (var t in treeStructure)
            {
                if(string.IsNullOrEmpty(t.ParentId))
                {
                }
                else if (t.IsNode)
                {
                    sb.AppendFormat("<div class='card p-0 m-0 border-0'>");

                    sb.AppendFormat("<div class='card-header bg-transparent p-0 m-0 border-0' ");
                    sb.AppendFormat($"id ='{TreeId}Heading{t.Key}'>");
                    if (t.ParentId == rootData.Key)
                    {
                        sb.AppendFormat("<button class='btn btn-link pl-0 pt-0 pb-0 m-0' data-toggle='collapse' ");
                    }
                    else
                    {
                        sb.AppendFormat("<button class='btn btn-link pl-2 pt-0 pb-0 m-0' data-toggle='collapse' ");
                    }

                    sb.AppendFormat("aria-expanded='true' ");
                    sb.AppendFormat($"data-target='#{TreeId}Collapse{t.Key}' ");
                    sb.AppendFormat($"aria-controls='{TreeId}Collapse{t.Key}'>");
                    sb.AppendFormat($"{t.Title} ({t.Count()})");
                    sb.AppendFormat("</button>");
                    sb.AppendFormat("</div>");

                    if (t.ParentId == rootData.Key)
                    {
                        sb.AppendFormat($"<div id='{TreeId}Collapse{t.Key}' class='collapse' aria-labelledby='{TreeId}Heading{t.Key}' data-parent='#{TreeId}'>");
                        sb.AppendFormat("<div class='card-body p-0 m-0 border-0'>");
                    }
                    else
                    {
                        sb.AppendFormat($"<div id='{TreeId}Collapse{t.Key}' class='collapse' aria-labelledby='{TreeId}Heading{t.Key}' data-parent='#{TreeId}Collapse{t.Key}'>");
                        sb.AppendFormat("<div class='card-body p-0 m-0 border-0'>");
                    }

                }
                else
                {
                    sb.AppendFormat("<div class='card pl-4 pt-0 pb-0 m-0 border-0'>");
                    sb.AppendFormat("<div class='card-body p-0 m-0 border-0'>");
                    sb.AppendFormat($"<a class='btn btn-default btn btn-link p-0 m-0' href='{t.Url}'>{t.Title}</a>");
                    sb.AppendFormat("</div>");
                    sb.AppendFormat("</div>");
                }

                sb.Append(CreateTree(t.Children, rootData));
                if (!string.IsNullOrEmpty(t.ParentId))
                {
                    sb.AppendFormat("</div>");
                    sb.AppendFormat("</div>");
                }
                
            }

            return sb.ToString();
        }

    }
}
