using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Devnuggets.Toolkit.Mvc
{
    public class CdnResource
    {
        public string Key { get; set; }
        public string Version { get; set; }
        public CdnSourceType CdnSource { get; set; }
        public string Url { get; set; }
        public bool Minified { get; set; }
        public int LoadSequence { get; set; }
        public ResourceType resourceType { get; set; }
    }

    public enum ResourceType { CSS, JS }
    public enum CdnSourceType { MICROSOFT_AJAX,GOOGLE,BOOTSTRAPCDN }

    public static class CdnHelper
    {
        private static List<CdnResource> GetResources()
        {
            List<CdnResource> resources = new List<CdnResource>();

            /*CSS*/
            resources.Add(new CdnResource() { Key = "jqueryui", Minified = true, resourceType = ResourceType.CSS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/themes/smoothness/jquery-ui.css", LoadSequence = 1 });
            resources.Add(new CdnResource() { Key = "bootstrap", Minified = false, resourceType = ResourceType.CSS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/bootstrap/3.1.0/css/bootstrap.min.css", LoadSequence = 0 });
            resources.Add(new CdnResource() { Key = "fontawesome", Minified = false, resourceType = ResourceType.CSS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.min.css", LoadSequence = 0 });
            resources.Add(new CdnResource() { Key = "datatables", Minified = true, resourceType = ResourceType.CSS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css", LoadSequence = 0 });
            /*JS*/
            resources.Add(new CdnResource() { Key = "jquery", Minified = true, resourceType = ResourceType.JS, CdnSource =  CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.0.min.js", LoadSequence = 1 });
            resources.Add(new CdnResource() { Key = "jquery", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.GOOGLE, Url = "//ajax.googleapis.com/ajax/libs/jquery/2.1.0/jquery.min.js", LoadSequence = 1 });
            resources.Add(new CdnResource() { Key = "jqueryui", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/jquery-ui.min.js", LoadSequence = 7 });
            resources.Add(new CdnResource() { Key = "knockout", Minified = false, resourceType = ResourceType.JS, CdnSource =  CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.0.0.js", LoadSequence = 2 });
            resources.Add(new CdnResource() { Key = "bootstrapjs", Minified = false, resourceType = ResourceType.JS, CdnSource =  CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/bootstrap/3.1.0/bootstrap.min.js", LoadSequence = 3 });
            resources.Add(new CdnResource() { Key = "jqueryvalidate", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js", LoadSequence = 4 });
            resources.Add(new CdnResource() { Key = "datatables", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/jquery.dataTables.min.js", LoadSequence = 5 });
            resources.Add(new CdnResource() { Key = "signalr", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "http://ajax.aspnetcdn.com/ajax/signalr/jquery.signalr-2.0.2.min.js", LoadSequence = 4 });
            resources.Add(new CdnResource() { Key = "angular", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "//ajax.googleapis.com/ajax/libs/angularjs/1.2.12/angular.min.js", LoadSequence = 4 });
            resources.Add(new CdnResource() { Key = "dojo", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "//ajax.googleapis.com/ajax/libs/dojo/1.9.2/dojo/dojo.js", LoadSequence = 4 });
            resources.Add(new CdnResource() { Key = "mootools", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "//ajax.googleapis.com/ajax/libs/mootools/1.4.5/mootools-yui-compressed.js", LoadSequence = 4 });
            resources.Add(new CdnResource() { Key = "prototype", Minified = true, resourceType = ResourceType.JS, CdnSource = CdnSourceType.MICROSOFT_AJAX, Url = "//ajax.googleapis.com/ajax/libs/prototype/1.7.1.0/prototype.js", LoadSequence = 4 });

            return resources;
        }


        private static string MakeScriptTag(CdnResource res)
        {
            //Render script tag
            string scriptTagString = null;
            if (res.resourceType == ResourceType.JS)
            {
                var scriptTag = new TagBuilder("script");
                scriptTag.Attributes["type"] = "text/javascript"; //This isn't really required with HTML 5 as this is the default.  As it does no real harm so I have left it for now. http://stackoverflow.com/a/9659074/761388
                scriptTag.Attributes["src"] = res.Url;
                scriptTagString = scriptTag.ToString();
            }
            if (res.resourceType == ResourceType.CSS)
            {
                var scriptTag = new TagBuilder("link");
                scriptTag.Attributes["rel"] = "stylesheet"; //This isn't really required with HTML 5 as this is the default.  As it does no real harm so I have left it for now. http://stackoverflow.com/a/9659074/761388
                scriptTag.Attributes["type"] = "text/css"; //This isn't really required with HTML 5 as this is the default.  As it does no real harm so I have left it for now. http://stackoverflow.com/a/9659074/761388
                scriptTag.Attributes["href"] = res.Url;
                scriptTagString = scriptTag.ToString();
            }

            return scriptTagString;
        }

        public static List<CdnResource> GetResources(string key, CdnSourceType preferredSource)
        {
            var res = GetResources().Where(w => w.Key == key && w.CdnSource == preferredSource).OrderBy(w => w.LoadSequence);
            if (res.Count() == 0)
            {
                res = GetResources().Where(w => w.Key == key).OrderBy(w => w.LoadSequence);
            }
            return res.ToList();
        }

        public static MvcHtmlString AddCdn(this HtmlHelper helper, List<string> cdnkeys, CdnSourceType preferredSource)
        {
            StringBuilder s = new StringBuilder();
            var items = new List<CdnResource>();

            foreach (string key in cdnkeys)
            {
                foreach (CdnResource r in GetResources(key, preferredSource))
                {
                    items.Add(r);
                }
            }

            foreach (CdnResource c in items.OrderBy(w=>w.LoadSequence))
            {
                s.Append(MakeScriptTag(c)+"\n");
            }
            return new MvcHtmlString(s.ToString());
        }
    }
}
