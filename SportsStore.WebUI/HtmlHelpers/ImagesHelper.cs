using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static string Image(this HtmlHelper helper,
                                    byte[] imageBytes)
        {
            if (imageBytes == null)
                return string.Empty;

            TagBuilder builder = new TagBuilder("img");
            
            byte[] imageData = null;
            string imageBase64 = string.Empty;
            string imageSrc = string.Empty;
        
            imageData = imageBytes;
            imageBase64 = Convert.ToBase64String(imageData);
            imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);

            builder.Attributes["src"] = imageSrc;
            string temp = builder.ToString();
            return builder.ToString();
        }
    }
}