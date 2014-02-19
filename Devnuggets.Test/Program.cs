using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devnuggets.Toolkit.Mvc;
using Devnuggets.Toolkit.MongoDb;
using System.Web;
using System.Web.Mvc;

namespace Devnuggets.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlHelper h = null;
            // get CDN hosted scripts - microsoft ajax CDN example
            Console.WriteLine(h.AddCdn(new List<string>(){"jquery","knockout","bootstrap","fontawesome","datatables"}, CdnSourceType.MICROSOFT_AJAX));
            // get CDN hosted scripts - Google CDN example
            Console.WriteLine(h.AddCdn(new List<string>() { "jquery", "knockout", "bootstrap", "datatables" }, CdnSourceType.GOOGLE));
            
            //connect to mongodb instance and run getstats command
            using (MongoConnection m = new MongoConnection("noptest", new MongoConnectionStringFromWebConfig())) // this loads the connection string from web.config > connectionstrings 
            {
                Console.WriteLine(m.GetStats());

                m.CompactCollections( new string[] {"collection1","collection2"});

            }
            Console.ReadLine();
        }
    }
}
