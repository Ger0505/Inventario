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
    public class ClienteContactosController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: ClienteContactos
        public ActionResult Index()
        {
            var clienteContacto = db.ClienteContacto.Include(c => c.Cliente).Include(c => c.Contacto);
            return View(clienteContacto.ToList());
        }

        // GET: ClienteContactos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteContacto clienteContacto = db.ClienteContacto.Find(id);
            if (clienteContacto == null)
            {
                return HttpNotFound();
            }
            return View(clienteContacto);
        }

        // GET: ClienteContactos/Create
        public ActionResult Create()
        {
            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo");
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion");
            return View();
        }

        // POST: ClienteContactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCli,IdCon,Descripcion")] ClienteContacto clienteContacto)
        {
            if (ModelState.IsValid)
            {
                db.ClienteContacto.Add(clienteContacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo", clienteContacto.IdCli);
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", clienteContacto.IdCon);
            return View(clienteContacto);
        }

        // GET: ClienteContactos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteContacto clienteContacto = db.ClienteContacto.Find(id);
            if (clienteContacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo", clienteContacto.IdCli);
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", clienteContacto.IdCon);
            return View(clienteContacto);
        }

        // POST: ClienteContactos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCli,IdCon,Descripcion")] ClienteContacto clienteContacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteContacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo", clienteContacto.IdCli);
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", clienteContacto.IdCon);
            return View(clienteContacto);
        }

        // GET: ClienteContactos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteContacto clienteContacto = db.ClienteContacto.Find(id);
            if (clienteContacto == null)
            {
                return HttpNotFound();
            }
            return View(clienteContacto);
        }

        // POST: ClienteContactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteContacto clienteContacto = db.ClienteContacto.Find(id);
            db.ClienteContacto.Remove(clienteContacto);
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
