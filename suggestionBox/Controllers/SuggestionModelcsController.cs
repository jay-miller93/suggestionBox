using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using suggestionBox.Models;

namespace suggestionBox.Controllers
{
    public class SuggestionModelcsController : Controller
    {
        private suggestionBoxContext db = new suggestionBoxContext();

        // GET: SuggestionModelcs
        public ActionResult Index()
        {
            return View(db.SuggestionModelcs.ToList());
        }

        // GET: SuggestionModelcs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionModelcs suggestionModelcs = db.SuggestionModelcs.Find(id);
            if (suggestionModelcs == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModelcs);
        }

        // GET: SuggestionModelcs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuggestionModelcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordNum,Topic,Suggestion")] SuggestionModelcs suggestionModelcs)
        {
            if (ModelState.IsValid)
            {
                db.SuggestionModelcs.Add(suggestionModelcs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suggestionModelcs);
        }

        // GET: SuggestionModelcs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionModelcs suggestionModelcs = db.SuggestionModelcs.Find(id);
            if (suggestionModelcs == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModelcs);
        }

        // POST: SuggestionModelcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordNum,Topic,Suggestion")] SuggestionModelcs suggestionModelcs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestionModelcs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestionModelcs);
        }

        // GET: SuggestionModelcs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestionModelcs suggestionModelcs = db.SuggestionModelcs.Find(id);
            if (suggestionModelcs == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModelcs);
        }

        // POST: SuggestionModelcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuggestionModelcs suggestionModelcs = db.SuggestionModelcs.Find(id);
            db.SuggestionModelcs.Remove(suggestionModelcs);
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
