using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult CheckTicket()
        {
            return View();
        }
        public ActionResult NextStep(int id, string date,string start, string end, string timeStart,int route)
        {
            ViewBag.IDCar = id;
            ViewBag.date = date;
            ViewBag.start = start;
            ViewBag.end = end;
            ViewBag.time = timeStart;
            ViewBag.idroute = route;

            return View();
        }

        public ActionResult Confirm(int id, string confirm)
        {
            ViewBag.idBill = id;
            ViewBag.confirmCode = confirm;
            return View();
        }

        public ActionResult NewDetal(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}