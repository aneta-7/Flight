using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Planes.Models;
using Flights.Models;
using PagedList;

namespace Planes.Controllers
{
    [RoutePrefix("Flights")]
    public class FlightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Flights
        [Route]
        public ActionResult Index( int? page)
        {
            var flight = db.Flights.OrderBy(s => s.Start);
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(flight.ToPagedList(pageNumber, pageSize));


            //  return View(db.Flights.ToList());
        }
        public JsonResult IndexPost(Models.Flight myDate)
        {
            return Json(new { Result = "OK" });
        }

        // GET: Flights/Details/5
        [Route("{id}")]
        public ActionResult Details(int? id)
        {
         
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                // return HttpNotFound();
                return Content("Brak strony");
            }
            return View(flight);
        }

        // GET: Flights/Create
        [Authorize]
        public ActionResult Create()
        {
            FlightViewModel model = new FlightViewModel();
            model.Planes = db.Planes.ToList();
            return View(model);
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID, Code,Start,Date1,Time1,Meta,Date2,Time2,SelectedPlaneID,Planes")] FlightViewModel flightViewModel)
        {
            if (ModelState.IsValid)
            {
                Flight flight = new Flight()
                {
                    Code = flightViewModel.Code,
                    Start = flightViewModel.Start,
                    Date1 = flightViewModel.Date1,
                    Time1 = flightViewModel.Time1,
                    Meta = flightViewModel.Meta,
                    Date2 = flightViewModel.Date2,
                    Time2 = flightViewModel.Time2,
                    Plane = db.Planes.Find(flightViewModel.SelectedPlaneID)
                };
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flightViewModel);
        }

        // GET: Flights/Edit/5
        [Authorize]
        [Route("{id}/edit")]
        public ActionResult Edit(int? id)
        {
            Flight flight = db.Flights.Find(id);
            FlightViewModel flightViewModel = new FlightViewModel();
            flightViewModel.Planes = db.Planes.ToList();
            flightViewModel.ID = flight.ID;
            flightViewModel.Code = flight.Code;
            flightViewModel.Start = flight.Start;
            flightViewModel.Date1 = flight.Date1;
            flightViewModel.Time1 = flight.Time1;
            flightViewModel.Meta = flight.Meta;
            flightViewModel.Date2 = flight.Date2;
            flightViewModel.Time2 = flight.Time2;
            flightViewModel.SelectedPlaneID = flight.Plane.ID;

            if (id == null)
            {
                //   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return Content("Brak strony");
            }
           
            if (flightViewModel == null)
            {
                return HttpNotFound();
            }
            return View(flightViewModel);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,Start,Date1,Time1,Meta,Date2,Time2,SelectedPlaneId, Planes")] FlightViewModel flightViewModel)
        {
           
            if (ModelState.IsValid)
            {
                Flight flight = db.Flights.Find(flightViewModel.ID);
                flight.Code = flightViewModel.Code;
                flight.Start = flightViewModel.Start;
                flight.Date1 = flightViewModel.Date1;
                flight.Time1 = flightViewModel.Time1;
                flight.Meta = flightViewModel.Meta;
                flight.Date2 = flightViewModel.Date2;
                flight.Time2 = flightViewModel.Time2;
                flight.Plane = db.Planes.Find(flightViewModel.SelectedPlaneID);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flightViewModel);
        }

        // GET: Flights/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return Content("Brak strony");
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            else if (!User.IsInRole("Admin")) 
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return Content("Brak uprawnień");
            }
            if (error != null)
                ViewBag.Error = true;

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, error = true });
            }
           return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
