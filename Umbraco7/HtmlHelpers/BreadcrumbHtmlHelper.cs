using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace UmbracoToolkit.Umbraco7.HtmlHelpers
{
    public static class BreadcrumbHtmlHelper
    {
        /// <summary>
        /// This Helper is specifically for Umbraco 
        /// </summary>
        public static MvcHtmlString BreadcrumbFor(this HtmlHelper helper)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            var model = helper.ViewData.Model as RenderModel;

            //NOTE: first node is pushed into list first so list may appear backwards when re-output
            List<IPublishedContent> publishedContent = new List<IPublishedContent>();
            publishedContent.Add(umbracoHelper.AssignedContentItem);//Add current context
            publishedContent.AddRange(umbracoHelper.AssignedContentItem.Ancestors().Where(t => t.IsVisible())); //Add the rest

            return new MvcHtmlString(BuildBreadcrumb(publishedContent));
        }

        private static string BuildBreadcrumb(List<IPublishedContent> publishedContent)
        {
            return BuildCrumbs(publishedContent, publishedContent.Count - 1);
        }

        private static string BuildCrumbs(List<IPublishedContent> publishedContent, int index)
        {
            var content = publishedContent[index];

            TagBuilder div = new TagBuilder("div");

            if (index == publishedContent.Count - 1)
                div.AddCssClass("breadcrumb");

            if (index != publishedContent.Count - 1)
                div.Attributes.Add("itemprop", "child");

            div.Attributes.Add("itemscope", "");
            div.Attributes.Add("itemtype", "http://data-vocabulary.org/Breadcrumb");

            TagBuilder title = new TagBuilder("span");
            title.Attributes.Add("itemprop", "title");
            title.InnerHtml = content.Name;

            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("itemprop", "url");
            a.Attributes.Add("href", content.Url);
            a.InnerHtml = title.ToString(TagRenderMode.Normal);

            div.InnerHtml = a.ToString();

            if (index != 0)
                div.InnerHtml += BuildCrumbs(publishedContent, index - 1);

            return div.ToString();
        }
    }
}
