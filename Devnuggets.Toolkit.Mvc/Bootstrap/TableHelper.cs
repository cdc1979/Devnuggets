using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web.Mvc;

namespace Devnuggets.Toolkit.Mvc
{


    public class TableOptions
    {


        public TableOptions()
        {
            EncloseWithPanel = RenderWithPanel.NONE;
        }
        public string TableRowId { get; set; }
        public string TableTitle { get; set; }
        public string TableId { get; set; }
        public SetTableStyle TableStyle { get; set; }
        public SetTableHover TableHover { get; set; }
        public SetTablePadding TablePadding { get; set; }
        public List<BootStrapButton> TableButtons = new List<BootStrapButton>();
        public List<string> TableHeadings = new List<string>();
        public RenderWithPanel EncloseWithPanel { get; set; }
        
    }
    
    public enum RenderWithPanel { NONE,DEFAULT,SUCCESS,INFO }

    public class BootStrapButton
    {
        public string ButtonText { get; set; }
        public BootStrapButtonSize ButtonSize { get;set ;}
        public int ButtonSequence { get; set; }
        public string ButtonHeader { get; set; }
        public BootStrapButtonStyle ButtonStyle { get; set; }

    }
    public enum BootStrapButtonSize { MINI,SMALL,NORMAL }
    public enum BootStrapButtonStyle { INFO,SUCCESS,PRIMARY,DANGER,WARNING,DEFAULT }
    public enum SetTableStyle { NORMAL,STRIPED }
    public enum SetTablePadding { NORMAL, CONDENSED }
    public enum SetTableHover { NOHOVER,HOVER }

    public static class TableHelper
    {
        public const TableOptions defaultTableOpts = null;

        // extension method for getting data annotations.
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }

        public static MvcHtmlString TableBuilder<T>(this HtmlHelper helper, List<T> items, TableOptions opts = null)
        {

            if (opts == null)
            {
                opts = new TableOptions();
                Type typeOfMyObject = items[0].GetType();
                PropertyInfo[] properties = typeOfMyObject.GetProperties();
                foreach (var p in properties)
                {
                    opts.TableHeadings.Add(p.Name);
                }
            }
            else
            {
                if (opts.TableHeadings.Count() == 0)
                {
                    Type typeOfMyObject = items[0].GetType();
                    PropertyInfo[] properties = typeOfMyObject.GetProperties();
                    foreach (var p in properties)
                    {
                        opts.TableHeadings.Add(p.Name);
                    }
                }
            }
            //Tags
            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("table");
            if (opts.TableStyle == SetTableStyle.STRIPED)
            {
                table.AddCssClass("table-striped");
            }
            if (opts.TableHover == SetTableHover.HOVER)
            {
                table.AddCssClass("table-hover");
            }
            
            TagBuilder tr = new TagBuilder("tr");
            TagBuilder td = new TagBuilder("td");
            TagBuilder th = new TagBuilder("th");

            //Inner html of table
            StringBuilder sb = new StringBuilder();

            //Add headers
            foreach (var s in opts.TableHeadings)
            {
                var p = "";
                var da = (DisplayAttribute[])(items[0].GetType().GetProperty(s).GetCustomAttributes(typeof(DisplayAttribute), true));
                if (da.Count() == 1)
                {
                    p = da[0].Name;
                }

                if (p.Length > 1)
                {
                    th.InnerHtml = p;
                }
                else
                {
                    th.InnerHtml = s;
                }

                tr.InnerHtml += th.ToString();
            }
            foreach (var b in opts.TableButtons)
            {
                th.InnerHtml = b.ButtonHeader;
                tr.InnerHtml += th.ToString();
            }
            sb.Append(tr.ToString());

            //Add data
            foreach (var d in items)
            {
                tr.InnerHtml = "";
                
                foreach (var h in opts.TableHeadings)
                {
                    td.InnerHtml = d.GetType().GetProperty(h).GetValue(d, null).ToString();
                    tr.InnerHtml += td.ToString();
                    if (h == opts.TableRowId)
                    {
                        tr.Attributes["rowid"] = d.GetType().GetProperty(h).GetValue(d, null).ToString();
                    }
                }

                foreach (var b in opts.TableButtons)
                {
                    td.InnerHtml = "<button class=\"" + b.ButtonText.ToLower().Replace(" ","-") + "\">" + b.ButtonText + "</button>";
                    tr.InnerHtml += td.ToString();
                }

                sb.Append(tr.ToString());
            }

            table.InnerHtml = sb.ToString();

            var outputstring = "";
            if (opts.EncloseWithPanel == RenderWithPanel.DEFAULT || opts.EncloseWithPanel == RenderWithPanel.INFO || opts.EncloseWithPanel == RenderWithPanel.SUCCESS )
            {
                TagBuilder paneldiv = new TagBuilder("div");
                switch(opts.EncloseWithPanel) {
                    case RenderWithPanel.DEFAULT:
                        paneldiv.AddCssClass("panel panel-default");
                        break;
                    case RenderWithPanel.INFO:
                        paneldiv.AddCssClass("panel panel-info");
                        break;
                    case RenderWithPanel.SUCCESS:
                        paneldiv.AddCssClass("panel panel-success");
                        break;
                }

                paneldiv.InnerHtml = "<div class=\"panel-heading\">" + opts.TableTitle + "</div>";
                paneldiv.InnerHtml += table.ToString();
                outputstring = paneldiv.ToString();
            }
            else
            {
                outputstring = table.ToString();
            }

            return new MvcHtmlString(outputstring);
        }
    }
}
