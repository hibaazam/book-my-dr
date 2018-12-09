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
    public class hospital_viewController : Controller
    {
        private FINALSCRIPTTEntities3 db = new FINALSCRIPTTEntities3();

        // GET: hospital_view
        public ActionResult Index()
        {
            return View(db.hospital_view.ToList());
        }

        public ActionResult Create1(int idee)
        {

            hospital_view p = new hospital_view();
            Hospital_request hospital_Request = db.Hospital_request.Find(idee);

            p.Hospital_day= hospital_Request.Hospital_day;
            p.patient_name = hospital_Request.patient_name;
            p.hospital_start_time = hospital_Request.Hospital_start_time;
            p.hospital_end_time = hospital_Request.hospital_end_time;
            
            db.hospital_view.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        public ActionResult Index1()
        {
            return View();
        }

        // GET: hospital_view/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_view hospital_view = db.hospital_view.Find(id);
            if (hospital_view == null)
            {
                return HttpNotFound();
            }
            return View(hospital_view);
        }

        // GET: hospital_view/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hospital_view/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hospital_end_time,hospital_start_time,patient_name,Hospital_day,id")] hospital_view hospital_view)
        {
            if (ModelState.IsValid)
            {
                db.hospital_view.Add(hospital_view);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital_view);
        }

        // GET: hospital_view/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_view hospital_view = db.hospital_view.Find(id);
            if (hospital_view == null)
            {
                return HttpNotFound();
            }
            return View(hospital_view);
        }

        // POST: hospital_view/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hospital_end_time,hospital_start_time,patient_name,Hospital_day,id")] hospital_view hospital_view)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital_view).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital_view);
        }

        // GET: hospital_view/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_view hospital_view = db.hospital_view.Find(id);
            if (hospital_view == null)
            {
                return HttpNotFound();
            }
            return View(hospital_view);
        }

        // POST: hospital_view/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hospital_view hospital_view = db.hospital_view.Find(id);
            db.hospital_view.Remove(hospital_view);
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
