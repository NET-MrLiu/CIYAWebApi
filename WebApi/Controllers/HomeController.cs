using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //var cm = new DbContext<HR_Employee_Info>();//不能把StudentManager变成静对象保证每次都NEW出来
            //var a = cm.GetList();
            return View();
        }
    }
}
