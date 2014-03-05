using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Devnuggets.Toolkit.Mvc
{

    public class Thumbnail
    {
        public string ImageUrl { get; set; }
        public int Sequence { get; set; }
        public string Heading { get; set; }
        public string Paragraph { get; set; }
        public List<BootStrapButton> buttons = new List<BootStrapButton>();
    }

    public static class ThumbnailHelper
    {
        public static MvcHtmlString ThumbnailBuilder(this HtmlHelper helper, List<Thumbnail> thumbnails, int cols)
        {
            StringBuilder content = new StringBuilder();
            var icount = 1;

            content.Append("<div class=\"row\">");

            var columns = (12 / cols);

            foreach (var t in thumbnails)
            {
                content.Append("<div class=\"col-md-" + (int)columns + "\">");
                content.Append("<div class=\"thumbnail\">");
                if (t.ImageUrl == null)
                {
                    content.Append("<img src=\"http://placehold.it/150x150\"/>");
                }

                if (!String.IsNullOrEmpty(t.Heading) || !String.IsNullOrEmpty(t.Paragraph) )
                {
                    content.Append("<div class=\"caption\">");
                    if (!String.IsNullOrEmpty(t.Heading))
                    {
                        content.Append("<h3>"+t.Heading+"</h3>");
                    }
                    if (!String.IsNullOrEmpty(t.Paragraph))
                    {
                        content.Append("<p>"+t.Paragraph+"</p>");
                    }

                    if (t.buttons.Count > 0)
                    {
                        content.Append("<p>");
                        foreach (BootStrapButton b in t.buttons) {
                            content.Append("<a href=\"#\" class=\"btn btn-primary\" role=\"button\">"+b.ButtonText+"</a>");
                        }
                        content.Append("</p>");
                    }


                    content.Append("</div>");
                }

                content.Append("</div></div>");

                if (icount % cols == 0)
                {
                    content.Append("</div><div class=\"row\">");
                }
                icount++;
            }



            return new MvcHtmlString(content.ToString());
        }
    }
}
