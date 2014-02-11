using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devnuggets.Toolkit.Mvc;
using System.Web;
using System.Web.Mvc;
namespace Devnuggets.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlHelper h = null;
            Console.WriteLine(h.AddCdn(new List<string>(){"jquery","knockout","bootstrap","fontawesome","datatables"}, CdnSourceType.MICROSOFT_AJAX));
            Console.WriteLine("\n\n\n");
            Console.WriteLine(h.AddCdn(new List<string>() { "jquery", "knockout", "bootstrap", "datatables" }, CdnSourceType.GOOGLE));
            Console.ReadLine();
        }
    }
}
