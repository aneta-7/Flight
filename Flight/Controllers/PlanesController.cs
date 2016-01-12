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
    public class PlanesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Planes
        public ViewResult Index(string sortOrder, string currentFilter, string searchName, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Type" ? "type_desc" : "Type";

            if (searchName != null)
            {
                page = 1;
            }
            else
            {
                searchName = currentFilter;
            }

            ViewBag.CurrentFilter = searchName;

            var planes = from p in db.Planes
                           select p;
            if (!String.IsNullOrEmpty(searchName))
            {
                planes = planes.Where(s => s.Name.Contains(searchName)
                                       || s.Type.Contains(searchName));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    planes = planes.OrderByDescending(s => s.Name);
                    break;
                case "Type":
                    planes = planes.OrderBy(s => s.Type);
                    break;
                case "type_desc":
                    planes = planes.OrderByDescending(s => s.Type);
                    break;
                default:  // Name ascending 
                    planes = planes.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(planes.ToPagedList(pageNumber, pageSize));
        }
        // return View(planes);

        //   return View(db.Planes.ToList());


        // GET: Planes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Planes.Find(id);
            if (plane == null)
            {
                //  return HttpNotFound();
                return Content("Brak strony");
            }
            return View(plane);
        }

        // GET: Planes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Name,Type")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                db.Planes.Add(plane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plane);
        }

        // GET: Planes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return Content("Brak strony");

            }
            Plane plane = db.Planes.Find(id);
            if (plane == null)
            {
                // return HttpNotFound();
                return Content("Brak strony");
                
            }
            return View(plane);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plane);
        }

        // GET: Planes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Planes.Find(id);
            if (plane == null)
            {
                //  return HttpNotFound();
                return Content("Brak strony");
            }
            else if (!User.IsInRole("Admin"))
            {
                //   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return Content("Brak uprawnień");
            }
            if (error != null)
                ViewBag.Error = true;

            return View(plane);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Plane plane = db.Planes.Find(id);
            db.Planes.Remove(plane);
            try {
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
