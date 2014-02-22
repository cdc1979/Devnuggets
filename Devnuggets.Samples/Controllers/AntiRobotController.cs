using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devnuggets.Toolkit.Mvc.AntiRobot;
namespace Devnuggets.Samples.Controllers
{
    public class AntiRobotController : Controller
    {
        //
        // GET: /AntiRobot/
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [AntiRobot(5)]
        public ActionResult Index(string Test)
        {
            Response.Write(Test);
            return View();
        }
	}
}