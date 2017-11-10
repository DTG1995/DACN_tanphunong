using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DACN_TanPhuNong
{
    public static class LanguageHelper
    {
        public static MvcHtmlString LangSwithcher(this UrlHelper url, RouteData routeData, string lang)
        {
            var liTagBuider = new TagBuilder("li");
            var aTagBuider = new TagBuilder("a");
            var imgTagBuider = new TagBuilder("img");

            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == lang)
                {
                    imgTagBuider.MergeAttribute("src", @"/images/" + lang + "_tron.png");
                    imgTagBuider.MergeAttribute("style", "border-radius: 50%;border: 2px solid #fff;");
                }
                else
                {
                    routeValueDictionary["lang"] = lang;
                    imgTagBuider.MergeAttribute("src", @"/images/" + lang + "_vuong.png");
                }
            }
            aTagBuider.MergeAttribute("href", url.RouteUrl(routeValueDictionary));

            aTagBuider.InnerHtml = imgTagBuider.ToString();
            liTagBuider.InnerHtml = aTagBuider.ToString();
            return new MvcHtmlString(liTagBuider.ToString());

        }
    }
}