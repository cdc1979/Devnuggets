using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devnuggets.Samples.Models;
namespace Devnuggets.Samples.Controllers
{
    public class TableController : Controller
    {
        //
        // GET: /Table/
        public ActionResult Index()
        {
            List<Customer> c = new List<Customer>();

            c.Add(new Customer() { Id = "1", CustomerEmail = "test1@test.com", CustomerName = "Dave", CustomerTel = "0777711111122" });
            c.Add(new Customer() { Id = "2", CustomerEmail = "test2@test.com", CustomerName = "Bob", CustomerTel = "0777711111133" });
            c.Add(new Customer() { Id = "3", CustomerEmail = "test3@test.com", CustomerName = "John", CustomerTel = "0777711111144" });
            c.Add(new Customer() { Id = "4", CustomerEmail = "test4@test.com", CustomerName = "Minion", CustomerTel = "0777711111155" });

            return View(c);
        }
	}
}