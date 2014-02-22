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
    public class TestModel {
        public string Test1 { get; set; }
        public string Test2 { get; set; }
        public string Test3 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TestModel> t = new List<TestModel>();
            t.Add(new TestModel() { Test1 = "data1",Test2 = "data2", Test3 = "data3" });
            t.Add(new TestModel() { Test1 = "data4", Test2 = "data5", Test3 = "data6" });
            t.Add(new TestModel() { Test1 = "data7", Test2 = "data8", Test3 = "data9" });

            HtmlHelper h = null;
            // get CDN hosted scripts - microsoft ajax CDN example
            Console.WriteLine(h.AddCdn(new List<string>(){"jquery","knockout","bootstrap","fontawesome","datatables"}, CdnSourceType.MICROSOFT_AJAX));
            // get CDN hosted scripts - Google CDN example
            Console.WriteLine(h.AddCdn(new List<string>() { "jquery", "knockout", "bootstrap", "datatables" }, CdnSourceType.GOOGLE));

            TableOptions tOpts = new TableOptions();
            tOpts.TableButtons.Add(new BootStrapButton() { ButtonStyle = BootStrapButtonStyle.SUCCESS, ButtonText = "Click", ButtonHeader = "Save", ButtonSequence = 1, ButtonSize = BootStrapButtonSize.NORMAL });
            tOpts.TableStyle = SetTableStyle.STRIPED;
            tOpts.TablePadding = SetTablePadding.NORMAL;
            tOpts.TableHover = SetTableHover.HOVER;
            tOpts.TableRowId = "Test1";
            tOpts.TableHeadings = new List<string>() { "Test1", "Test2", "Test3" };

            Console.WriteLine(h.TableBuilder<TestModel>(t, tOpts));

            //connect to mongodb instance and run getstats command
            using (MongoConnection m = new MongoConnection("noptest", new MongoConnectionStringFromWebConfig())) // this loads the connection string from web.config > connectionstrings 
            {
                try
                {
                    Console.WriteLine(m.GetStats());
                    m.CompactCollections(new string[] { "collection1", "collection2" });
                }
                catch { }

            }
            Console.ReadLine();
        }
    }
}
