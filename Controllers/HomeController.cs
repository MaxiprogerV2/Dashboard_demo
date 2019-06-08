using AspExample_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspExample_v1._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Description(string Name)
        {
            ViewBag.Name = Name;
            return View();
        }
        public ActionResult Robots()
        {
            //    LogsReader logsReader = new LogsReader(                                                                                                                                                                                             );

            //    var RobbieInfo = logsReader.GetCurrentStatus("Robbie");

            //    ViewBag.RobbieStatus = RobbieInfo.Value;
            //    ViewBag.RobbieStatusTime = RobbieInfo.Key;

            //    ViewBag.RobotsList = new List<String>
            //    {
            //        "Robbie",
            //        "Little Brother",
            //        "Справочник"
            //    };

            return View();
        }

        public ActionResult GetRobots()
        {
            LogsReader logsReader = new LogsReader();


            //var RobbieInfo = logsReader.GetCurrentStatus("Robbie");
            //var LittleBrotherInfo = logsReader.GetCurrentStatus("LittleBrother");
            //var Справочник = logsReader.GetCurrentStatus("Справочник");

            //var list = new List<String>
            //{
            //    //"Robbie: " + RobbieInfo.Value,
            //    //"Little Brother: " + LittleBrotherInfo.Value,
            //    //"Справочник: " + Справочник.Value
            //    "Robbie",
            //    "Little Brother" ,
            //    "Справочник"
            //};

            var list = logsReader.getInfo();

            return PartialView(list);
        }
    }
}