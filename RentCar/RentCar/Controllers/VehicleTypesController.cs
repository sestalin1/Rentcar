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
    public class VehicleTypesController : Controller
    {
        private RENTCARTEntities1 db = new RENTCARTEntities1();

        // GET: /VehicleTypes/
        public async Task<ActionResult> Index()
        {
            return View(await db.VehicleTypes.ToListAsync());
        }

        // GET: /VehicleTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleTypes vehicletypes = await db.VehicleTypes.FindAsync(id);
            if (vehicletypes == null)
            {
                return HttpNotFound();
            }
            return View(vehicletypes);
        }

        // GET: /VehicleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VehicleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Description,State")] VehicleTypes vehicletypes)
        {
            if (ModelState.IsValid)
            {
                db.VehicleTypes.Add(vehicletypes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vehicletypes);
        }

        // GET: /VehicleTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleTypes vehicletypes = await db.VehicleTypes.FindAsync(id);
            if (vehicletypes == null)
            {
                return HttpNotFound();
            }
            return View(vehicletypes);
        }

        // POST: /VehicleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Description,State")] VehicleTypes vehicletypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicletypes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicletypes);
        }

        // GET: /VehicleTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleTypes vehicletypes = await db.VehicleTypes.FindAsync(id);
            if (vehicletypes == null)
            {
                return HttpNotFound();
            }
            return View(vehicletypes);
        }

        // POST: /VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleTypes vehicletypes = await db.VehicleTypes.FindAsync(id);
            db.VehicleTypes.Remove(vehicletypes);
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
