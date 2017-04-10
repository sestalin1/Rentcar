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
    public class RentAndReturnsController : Controller
    {
        private RENTCARTEntities1 db = new RENTCARTEntities1();

        // GET: /RentAndReturns/
        public async Task<ActionResult> Index()
        {
            var rentandreturns = db.RentAndReturns.Include(r => r.Clients).Include(r => r.Employees).Include(r => r.Vehicles);
            return View(await rentandreturns.ToListAsync());
        }

        // GET: /RentAndReturns/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAndReturns rentandreturns = await db.RentAndReturns.FindAsync(id);
            if (rentandreturns == null)
            {
                return HttpNotFound();
            }
            return View(rentandreturns);
        }

        // GET: /RentAndReturns/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description");
            return View();
        }

        // POST: /RentAndReturns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,VehicleID,ClientID,EmployeeID,RentDate,ReturnDate,AmountXDay,NumberOfDays,Comment,State")] RentAndReturns rentandreturns)
        {
            if (ModelState.IsValid)
            {
                db.RentAndReturns.Add(rentandreturns);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre", rentandreturns.ClientID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre", rentandreturns.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description", rentandreturns.VehicleID);
            return View(rentandreturns);
        }

        // GET: /RentAndReturns/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAndReturns rentandreturns = await db.RentAndReturns.FindAsync(id);
            if (rentandreturns == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre", rentandreturns.ClientID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre", rentandreturns.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description", rentandreturns.VehicleID);
            return View(rentandreturns);
        }

        // POST: /RentAndReturns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,VehicleID,ClientID,EmployeeID,RentDate,ReturnDate,AmountXDay,NumberOfDays,Comment,State")] RentAndReturns rentandreturns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentandreturns).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Nombre", rentandreturns.ClientID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Nombre", rentandreturns.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Description", rentandreturns.VehicleID);
            return View(rentandreturns);
        }

        // GET: /RentAndReturns/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAndReturns rentandreturns = await db.RentAndReturns.FindAsync(id);
            if (rentandreturns == null)
            {
                return HttpNotFound();
            }
            return View(rentandreturns);
        }

        // POST: /RentAndReturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RentAndReturns rentandreturns = await db.RentAndReturns.FindAsync(id);
            db.RentAndReturns.Remove(rentandreturns);
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
