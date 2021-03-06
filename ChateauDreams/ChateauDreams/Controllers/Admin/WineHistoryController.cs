﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChateauDreams.Models;
using ChateauDreams.Models.Enotourism;

namespace ChateauDreams.Controllers.Admin
{
    public class WineHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WineHistory
        public ActionResult Index()
        {
            return View("~/Views/Enotourism/WineHistory/WineHistory.cshtml", db.WineHistories.ToList());
        }

        // GET: WineHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineHistory wineHistory = db.WineHistories.Find(id);
            if (wineHistory == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Enotourism/WineHistory/Details.cshtml", wineHistory);
        }

        // GET: WineHistory/Create
        public ActionResult Create()
        {
            return View("~/Views/Enotourism/WineHistory/Create.cshtml");
        }

        // POST: WineHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] WineHistory wineHistory)
        {
            if (ModelState.IsValid)
            {
                db.WineHistories.Add(wineHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wineHistory);
        }

        // GET: WineHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineHistory wineHistory = db.WineHistories.Find(id);
            if (wineHistory == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Enotourism/WineHistory/Edit.cshtml", wineHistory);
        }

        // POST: WineHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] WineHistory wineHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wineHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wineHistory);
        }

        // GET: WineHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineHistory wineHistory = db.WineHistories.Find(id);
            if (wineHistory == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Enotourism/WineHistory/Delete.cshtml", wineHistory);
        }

        // POST: WineHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WineHistory wineHistory = db.WineHistories.Find(id);
            db.WineHistories.Remove(wineHistory);
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
