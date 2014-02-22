using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Devnuggets.Toolkit.Mvc.AntiRobot
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AntiRobotAttribute : ActionFilterAttribute, IActionFilter
    {
        private int _seconds;

        public AntiRobotAttribute(int seconds)
        {
            _seconds = seconds;
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request["_generatedTimeStamp"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult("No Timestamp Supplied Make sure you have added @Html.AntiRobot into your form");
            }
            else
            {
                long currentTimestamp = DateTime.UtcNow.Ticks;
                long passedTimestamp = long.Parse(filterContext.HttpContext.Request["_generatedTimeStamp"]);
                var elapsedTicks = currentTimestamp - passedTimestamp;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                if (elapsedSpan.TotalSeconds < _seconds)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }

            if (filterContext.HttpContext.Request["_honeyPot"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult("No HoneyPot Supplied Make sure you have added @Html.AntiRobot into your form");
            }
            else
            {
                if (filterContext.HttpContext.Request["_honeyPot"].Length > 1)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
            //throw new NotImplementedException();

        }
        
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }

    public static class AntiRobotHelper
    {
        public static MvcHtmlString AntiRobot(this HtmlHelper helper)
        {
            TagBuilder t = new TagBuilder("input");
            t.Attributes["type"] = "hidden";
            t.Attributes["name"] = "_generatedTimeStamp";
            t.Attributes["value"] = DateTime.UtcNow.Ticks.ToString();

            TagBuilder tx = new TagBuilder("input");
            tx.Attributes["style"] = "display:none;";
            tx.Attributes["name"] = "_honeyPot";
            tx.Attributes["type"] = "text";

            return new MvcHtmlString(t.ToString() + tx.ToString());
        }
    }

}
