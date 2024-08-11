using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngresoGastos.Data;
using IngresoGastos.Models;

namespace IngresoGastos.Controllers
{
    public class IngresoGastosController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: IngresoGastos
        public ActionResult Index()
        {
            //vamos a crear tres variables para asi poder realizar el proceso de las sumas los g

            double ingresos, gastos, neto;
            
            ingresos = db.ingresosGastos.Where(m => m.EsIngreso == true).Select(p => p.Valor).DefaultIfEmpty(0.0).Sum();
            gastos = db.ingresosGastos.Where(m => m.EsIngreso == false).Select(p => p.Valor).DefaultIfEmpty(0.0).Sum();
            neto = ingresos - gastos;
           
            //realizamos con la funcion Viewbag para poderla utilizar en nuestra vistas 
            ViewBag.Ingresos = ingresos;
            ViewBag.Gastos = gastos;
            ViewBag.Netos = neto;  

            return View(db.ingresosGastos.ToList());
        }

        // GET: IngresoGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastostatis ingresoGastostatis = db.ingresosGastos.Find(id);
            if (ingresoGastostatis == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastostatis);
        }

        // GET: IngresoGastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngresoGastos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastostatis ingresoGastostatis)
        {
            if (ModelState.IsValid)
            {
                db.ingresosGastos.Add(ingresoGastostatis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingresoGastostatis);
        }

        // GET: IngresoGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastostatis ingresoGastostatis = db.ingresosGastos.Find(id);
            if (ingresoGastostatis == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastostatis);
        }

        // POST: IngresoGastos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastostatis ingresoGastostatis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresoGastostatis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingresoGastostatis);
        }

        // GET: IngresoGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastostatis ingresoGastostatis = db.ingresosGastos.Find(id);
            if (ingresoGastostatis == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastostatis);
        }

        // POST: IngresoGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresoGastostatis ingresoGastostatis = db.ingresosGastos.Find(id);
            db.ingresosGastos.Remove(ingresoGastostatis);
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
