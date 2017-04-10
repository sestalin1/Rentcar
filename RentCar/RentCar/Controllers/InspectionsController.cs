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
    public class InspectionsController : Controller
    {
        private RENTCARTEntities1 db = new RENTCARTEntities1();

        // GET: /Inspections/
        public async Task<ActionResult> Index()
        {
            var inspections = db.Inspections.Include(i => i.Clients).Include(i => i.Employees).Include(i => i.Vehicles);
            return View(await inspections.ToListAsync());
        }

        // GET: /Inspections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspections inspections = await db.Inspections.FindAsync(id);
            if (inspections == null)
            {
                return HttpNotFound();
            }
            return View(inspections);
        }

        // GET: /Inspections/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description");
            return View();
        }

        // POST: /Inspections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,VehicleID,ClientID,HaveScratches,FuelAmount,HasSpareTire,HasJack,HaveBrokenGlass,Date,EmployeeID,TiresSate,State")] Inspections inspections)
        {
            if (ModelState.IsValid)
            {
                db.Inspections.Add(inspections);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre", inspections.ClientID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre", inspections.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description", inspections.VehicleID);
            return View(inspections);
        }

        // GET: /Inspections/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspections inspections = await db.Inspections.FindAsync(id);
            if (inspections == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre", inspections.ClientID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre", inspections.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description", inspections.VehicleID);
            return View(inspections);
        }

        // POST: /Inspections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,VehicleID,ClientID,HaveScratches,FuelAmount,HasSpareTire,HasJack,HaveBrokenGlass,Date,EmployeeID,TiresSate,State")] Inspections inspections)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspections).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre", inspections.ClientID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre", inspections.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description", inspections.VehicleID);
            return View(inspections);
        }

        // GET: /Inspections/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspections inspections = await db.Inspections.FindAsync(id);
            if (inspections == null)
            {
                return HttpNotFound();
            }
            return View(inspections);
        }

        // POST: /Inspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inspections inspections = await db.Inspections.FindAsync(id);
            db.Inspections.Remove(inspections);
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
