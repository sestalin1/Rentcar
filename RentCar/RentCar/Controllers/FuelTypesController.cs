﻿using System;
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
    public class FuelTypesController : Controller
    {
        private RENTCARTEntities1 db = new RENTCARTEntities1();

        // GET: /FuelTypes/
        public async Task<ActionResult> Index()
        {
            return View(await db.FuelTypes.ToListAsync());
        }

        // GET: /FuelTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelTypes fueltypes = await db.FuelTypes.FindAsync(id);
            if (fueltypes == null)
            {
                return HttpNotFound();
            }
            return View(fueltypes);
        }

        // GET: /FuelTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FuelTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Description,State")] FuelTypes fueltypes)
        {
            if (ModelState.IsValid)
            {
                db.FuelTypes.Add(fueltypes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fueltypes);
        }

        // GET: /FuelTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelTypes fueltypes = await db.FuelTypes.FindAsync(id);
            if (fueltypes == null)
            {
                return HttpNotFound();
            }
            return View(fueltypes);
        }

        // POST: /FuelTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Description,State")] FuelTypes fueltypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fueltypes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fueltypes);
        }

        // GET: /FuelTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelTypes fueltypes = await db.FuelTypes.FindAsync(id);
            if (fueltypes == null)
            {
                return HttpNotFound();
            }
            return View(fueltypes);
        }

        // POST: /FuelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FuelTypes fueltypes = await db.FuelTypes.FindAsync(id);
            db.FuelTypes.Remove(fueltypes);
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
