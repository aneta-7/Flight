using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flights.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult IndexPost(Models.FlightViewModel myDate)
        {
            return Json(new { Result = "OK" });
        }

    }
}