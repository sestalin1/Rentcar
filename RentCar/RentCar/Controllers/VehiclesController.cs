using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar;

namespace RentCar.Controllers
{
    public class VehiclesController : Controller
    {
        private RENTCARTEntities1 db = new RENTCARTEntities1();

        // GET: /Vehicles/
        public async Task<ActionResult> Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Brands).Include(v => v.VehicleModels).Include(v => v.VehicleTypes);
            return View(await vehicles.ToListAsync());
        }

        // GET: /Vehicles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles vehicles = await db.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return HttpNotFound();
            }
            return View(vehicles);
        }

        // GET: /Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.FuelTypeID = new SelectList(db.Brands, "ID", "Description");
            ViewBag.ModelID = new SelectList(db.VehicleModels, "ID", "Description");
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "ID", "Description");
            return View();
        }

        // POST: /Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Description,ChassisNumber,EngineNumber,PlateNumber,VehicleTypeID,BrandID,ModelID,FuelTypeID,State")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FuelTypeID = new SelectList(db.Brands, "ID", "Description", vehicles.FuelTypeID);
            ViewBag.ModelID = new SelectList(db.VehicleModels, "ID", "Description", vehicles.ModelID);
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "ID", "Description", vehicles.VehicleTypeID);
            return View(vehicles);
        }

        // GET: /Vehicles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles vehicles = await db.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuelTypeID = new SelectList(db.Brands, "ID", "Description", vehicles.FuelTypeID);
            ViewBag.ModelID = new SelectList(db.VehicleModels, "ID", "Description", vehicles.ModelID);
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "ID", "Description", vehicles.VehicleTypeID);
            return View(vehicles);
        }

        // POST: /Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Description,ChassisNumber,EngineNumber,PlateNumber,VehicleTypeID,BrandID,ModelID,FuelTypeID,State")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FuelTypeID = new SelectList(db.Brands, "ID", "Description", vehicles.FuelTypeID);
            ViewBag.ModelID = new SelectList(db.VehicleModels, "ID", "Description", vehicles.ModelID);
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "ID", "Description", vehicles.VehicleTypeID);
            return View(vehicles);
        }

        // GET: /Vehicles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles vehicles = await db.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return HttpNotFound();
            }
            return View(vehicles);
        }

        // POST: /Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vehicles vehicles = await db.Vehicles.FindAsync(id);
            db.Vehicles.Remove(vehicles);
            await db.SaveChangesAsync();
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
