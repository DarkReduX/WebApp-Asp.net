using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Models;

namespace WebApplicationProject.Helper
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination justify-content-center");
            result.Append(ulTag.ToString(TagRenderMode.StartTag));
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder listTag = new TagBuilder("li");
                TagBuilder aTag = new TagBuilder("a");
                if (i != pageInfo.PageNumber)
                    aTag.MergeAttribute("href", pageUrl(i));
                aTag.InnerHtml = i.ToString();
                if (i == pageInfo.PageNumber)
                {
                    listTag.AddCssClass("page-item disabled");
                }
                listTag.AddCssClass("page-item");
                result.Append(listTag.ToString(TagRenderMode.StartTag));
                result.Append(aTag.ToString());
                result.Append(listTag.ToString(TagRenderMode.EndTag));
            }
            result.Append(ulTag.ToString(TagRenderMode.EndTag));
            return MvcHtmlString.Create(result.ToString());
        }
    }
}