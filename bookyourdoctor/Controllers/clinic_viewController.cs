using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookyourdoctor;

namespace bookyourdoctor.Controllers
{
    public class clinic_viewController : Controller
    {
        private FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3();

        // GET: clinic_view
        public ActionResult Index()
        {
            return View(db.clinic_view.ToList());
        }

        public ActionResult Create1(int idee)
        {
            clinic_view p = new clinic_view();
            Clinic_request clinic_request = db.Clinic_request.Find(idee);
            
            p.Clinic_day = clinic_request.clinic_day;
            p.patient_name = clinic_request.patient_name;
            p.clinic_start_time = clinic_request.clinic_start_time;
            p.clinic_end_time = clinic_request.clinic_end_time;
            
            db.clinic_view.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        public ActionResult Index1()
        {
            return View();
        }



        // GET: clinic_view/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinic_view clinic_view = db.clinic_view.Find(id);
            if (clinic_view == null)
            {
                return HttpNotFound();
            }
            return View(clinic_view);
        }

        // GET: clinic_view/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clinic_view/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clinic_start_time,clinic_end_time,patient_name,Clinic_day,id")] clinic_view clinic_view)
        {
            if (ModelState.IsValid)
            {
                db.clinic_view.Add(clinic_view);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clinic_view);
        }

        // GET: clinic_view/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinic_view clinic_view = db.clinic_view.Find(id);
            if (clinic_view == null)
            {
                return HttpNotFound();
            }
            return View(clinic_view);
        }

        // POST: clinic_view/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clinic_start_time,clinic_end_time,patient_name,Clinic_day,id")] clinic_view clinic_view)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinic_view).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinic_view);
        }

        // GET: clinic_view/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinic_view clinic_view = db.clinic_view.Find(id);
            if (clinic_view == null)
            {
                return HttpNotFound();
            }
            return View(clinic_view);
        }

        // POST: clinic_view/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clinic_view clinic_view = db.clinic_view.Find(id);
            db.clinic_view.Remove(clinic_view);
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
