using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario;

namespace Inventario.Controllers
{
    public class DetallesController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Detalles
        public ActionResult Index()
        {
            var detalle = db.Detalle.Include(d => d.Cabecera).Include(d => d.Producto);
            return View(detalle.ToList());
        }

        // GET: Detalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            ViewBag.IdCab = new SelectList(db.Cabecera, "IdCab", "Fecha");
            ViewBag.IdPro = new SelectList(db.Producto, "IdPro", "Nombre");
            return View();
        }

        // POST: Detalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDet,IdCab,IdPro,Cantidad,Total")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Detalle.Add(detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCab = new SelectList(db.Cabecera, "IdCab", "Fecha", detalle.IdCab);
            ViewBag.IdPro = new SelectList(db.Producto, "IdPro", "Nombre", detalle.IdPro);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCab = new SelectList(db.Cabecera, "IdCab", "Fecha", detalle.IdCab);
            ViewBag.IdPro = new SelectList(db.Producto, "IdPro", "Nombre", detalle.IdPro);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDet,IdCab,IdPro,Cantidad,Total")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCab = new SelectList(db.Cabecera, "IdCab", "Fecha", detalle.IdCab);
            ViewBag.IdPro = new SelectList(db.Producto, "IdPro", "Nombre", detalle.IdPro);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle detalle = db.Detalle.Find(id);
            db.Detalle.Remove(detalle);
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
