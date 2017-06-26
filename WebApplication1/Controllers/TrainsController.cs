using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TrainsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Search()
        {
            ViewBag.From = new SelectList(db.Cities, "Id", "Name");
            ViewBag.To = new SelectList(db.Cities, "Id", "Name");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search([Bind(Include = "From, To, Date, Hour")] BindModel bindModel)
        {
            ViewBag.From = new SelectList(db.Cities, "Id", "Name");
            ViewBag.To = new SelectList(db.Cities, "Id", "Name");           
            
            if(bindModel.From != 0 && bindModel.To != 0 && bindModel.Date != null && bindModel.Hour != null)
            {
                var trainList = db.Trains.Where(
                    s => s.From == bindModel.From && 
                         s.To == bindModel.To && 
                         s.StartDate == bindModel.Date && 
                         s.StartTime > bindModel.Hour).
                         OrderBy(s => s.StartTime).ToList();

                return View(trainList);
            }

            if (bindModel.From != 0 && bindModel.Date != null)
            {
                var trainList = db.Trains.Where(
                    s => s.From == bindModel.From &&
                         s.StartDate == bindModel.Date).
                         OrderBy(s => s.StartTime).ToList();

                return View(trainList);
            }

            if (bindModel.To != 0 && bindModel.Date != null)
            {
                var trainList = db.Trains.Where(
                    s => s.To == bindModel.To &&
                         s.StartDate == bindModel.Date).
                         OrderBy(s => s.StartTime).ToList();

                return View(trainList);
            }


            



            return View();
        }

        // GET: Trains
        public ActionResult Index()
        {
            var result = db.Trains.ToList();
            return View(db.Trains.ToList());
        }

        // GET: Trains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Train train = db.Trains.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // GET: Trains/Create
        public ActionResult Create()
        {
            ViewBag.From = new SelectList(db.Cities, "Id", "Name");
            ViewBag.To = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        // POST: Trains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,From,To,StartDate,EndDate,StartTime,EndTime")] Train train)
        {
            if (ModelState.IsValid)
            {
                ViewBag.From = new SelectList(db.Cities, "Id", "Name");
                ViewBag.To = new SelectList(db.Cities, "Id", "Name");

                db.Trains.Add(train);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(train);
        }

        // GET: Trains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Train train = db.Trains.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // POST: Trains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,From,To,DepartureTime,ArrivalTime,StartTime,EndTime")] Train train)
        {
            if (ModelState.IsValid)
            {
                db.Entry(train).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(train);
        }

        // GET: Trains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Train train = db.Trains.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // POST: Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Train train = db.Trains.Find(id);
            db.Trains.Remove(train);
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
