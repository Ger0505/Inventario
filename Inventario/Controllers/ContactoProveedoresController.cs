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
    public class ContactoProveedoresController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: ContactoProveedores
        public ActionResult Index()
        {
            var contacto_Proveedor = db.Contacto_Proveedor.Include(c => c.Contacto).Include(c => c.Proveedor);
            return View(contacto_Proveedor.ToList());
        }

        // GET: ContactoProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            if (contacto_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(contacto_Proveedor);
        }

        // GET: ContactoProveedores/Create
        public ActionResult Create()
        {
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion");
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre");
            return View();
        }

        // POST: ContactoProveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCon,IdProv,Descripcion")] Contacto_Proveedor contacto_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Contacto_Proveedor.Add(contacto_Proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", contacto_Proveedor.IdCon);
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre", contacto_Proveedor.IdProv);
            return View(contacto_Proveedor);
        }

        // GET: ContactoProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            if (contacto_Proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", contacto_Proveedor.IdCon);
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre", contacto_Proveedor.IdProv);
            return View(contacto_Proveedor);
        }

        // POST: ContactoProveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCon,IdProv,Descripcion")] Contacto_Proveedor contacto_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto_Proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", contacto_Proveedor.IdCon);
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre", contacto_Proveedor.IdProv);
            return View(contacto_Proveedor);
        }

        // GET: ContactoProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            if (contacto_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(contacto_Proveedor);
        }

        // POST: ContactoProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            db.Contacto_Proveedor.Remove(contacto_Proveedor);
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
