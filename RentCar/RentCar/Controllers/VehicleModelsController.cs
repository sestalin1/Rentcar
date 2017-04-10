using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar;

namespace RentCar.Controllers
{
    public class VehicleModelsController : Controller
    {
        private RENTCARTEntities1 db = new RENTCARTEntities1();

        // GET: /VehicleModels/
        public ActionResult Index()
        {
            var vehiclemodels = db.VehicleModels.Include(v => v.Brands);
            return View(vehiclemodels.ToList());
        }

        // GET: /VehicleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModels vehiclemodels = db.VehicleModels.Find(id);
            if (vehiclemodels == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemodels);
        }

        // GET: /VehicleModels/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Description");
            return View();
        }

        // POST: /VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,BrandID,Description,State")] VehicleModels vehiclemodels)
        {
            if (ModelState.IsValid)
            {
                db.VehicleModels.Add(vehiclemodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Description", vehiclemodels.BrandID);
            return View(vehiclemodels);
        }

        // GET: /VehicleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModels vehiclemodels = db.VehicleModels.Find(id);
            if (vehiclemodels == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Description", vehiclemodels.BrandID);
            return View(vehiclemodels);
        }

        // POST: /VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,BrandID,Description,State")] VehicleModels vehiclemodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclemodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Description", vehiclemodels.BrandID);
            return View(vehiclemodels);
        }

        // GET: /VehicleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModels vehiclemodels = db.VehicleModels.Find(id);
            if (vehiclemodels == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemodels);
        }

        // POST: /VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleModels vehiclemodels = db.VehicleModels.Find(id);
            db.VehicleModels.Remove(vehiclemodels);
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
