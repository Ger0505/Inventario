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
    public class CabecerasController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Cabeceras
        public ActionResult Index()
        {
            var cabecera = db.Cabecera.Include(c => c.Cliente).Include(c => c.Departamento).Include(c => c.Empleado).Include(c => c.Movimiento);
            return View(cabecera.ToList());
        }

        // GET: Cabeceras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabecera cabecera = db.Cabecera.Find(id);
            if (cabecera == null)
            {
                return HttpNotFound();
            }
            return View(cabecera);
        }

        // GET: Cabeceras/Create
        public ActionResult Create()
        {
            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo");
            ViewBag.IdDep = new SelectList(db.Departamento, "IdDep", "Nombre");
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "Sueldo");
            ViewBag.IdMov = new SelectList(db.Movimiento, "IdMov", "Descripcion");
            return View();
        }

        // POST: Cabeceras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCab,IdMov,IdCli,IdEmp,IdDep,Fecha")] Cabecera cabecera)
        {
            if (ModelState.IsValid)
            {
                db.Cabecera.Add(cabecera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo", cabecera.IdCli);
            ViewBag.IdDep = new SelectList(db.Departamento, "IdDep", "Nombre", cabecera.IdDep);
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "Sueldo", cabecera.IdEmp);
            ViewBag.IdMov = new SelectList(db.Movimiento, "IdMov", "Descripcion", cabecera.IdMov);
            return View(cabecera);
        }

        // GET: Cabeceras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabecera cabecera = db.Cabecera.Find(id);
            if (cabecera == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo", cabecera.IdCli);
            ViewBag.IdDep = new SelectList(db.Departamento, "IdDep", "Nombre", cabecera.IdDep);
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "Sueldo", cabecera.IdEmp);
            ViewBag.IdMov = new SelectList(db.Movimiento, "IdMov", "Descripcion", cabecera.IdMov);
            return View(cabecera);
        }

        // POST: Cabeceras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCab,IdMov,IdCli,IdEmp,IdDep,Fecha")] Cabecera cabecera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cabecera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCli = new SelectList(db.Cliente, "IdCli", "Tipo", cabecera.IdCli);
            ViewBag.IdDep = new SelectList(db.Departamento, "IdDep", "Nombre", cabecera.IdDep);
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "Sueldo", cabecera.IdEmp);
            ViewBag.IdMov = new SelectList(db.Movimiento, "IdMov", "Descripcion", cabecera.IdMov);
            return View(cabecera);
        }

        // GET: Cabeceras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabecera cabecera = db.Cabecera.Find(id);
            if (cabecera == null)
            {
                return HttpNotFound();
            }
            return View(cabecera);
        }

        // POST: Cabeceras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cabecera cabecera = db.Cabecera.Find(id);
            db.Cabecera.Remove(cabecera);
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
