using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers.MVC
{
    public class HotelModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HotelModels
        public ActionResult Index()
        {
            return View(db.HotelModels.ToList());
        }

        // GET: HotelModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelModel hotelModel = db.HotelModels.Find(id);
            if (hotelModel == null)
            {
                return HttpNotFound();
            }
            return View(hotelModel);
        }

        // GET: HotelModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Stars,Address")] HotelModel hotelModel)
        {
            if (ModelState.IsValid)
            {
                db.HotelModels.Add(hotelModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelModel);
        }

        // GET: HotelModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelModel hotelModel = db.HotelModels.Find(id);
            if (hotelModel == null)
            {
                return HttpNotFound();
            }
            return View(hotelModel);
        }

        // POST: HotelModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Stars,Address")] HotelModel hotelModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelModel);
        }

        // GET: HotelModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelModel hotelModel = db.HotelModels.Find(id);
            if (hotelModel == null)
            {
                return HttpNotFound();
            }
            return View(hotelModel);
        }

        // POST: HotelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelModel hotelModel = db.HotelModels.Find(id);
            db.HotelModels.Remove(hotelModel);
            db.SaveChanges();
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
