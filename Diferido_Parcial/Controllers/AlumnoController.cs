using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diferido_Parcial.Models;

namespace Diferido_Parcial.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno


        implent_Alumno ci = new implent_Alumno();


        public ActionResult alumno()
        {
            ModelState.Clear();
            return View(ci.GetAlumns());
        }

      

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {

            return View(ci.GetAlumns().Find(itemodel => itemodel.CodAlumno == id));
           
        }

        // GET: Alumno/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(Alumn inserAlun)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ci.insertal(inserAlun))
                    {
                        ViewBag.message = "Guardado completo";
                        ModelState.Clear();
                    }
                }

                return RedirectToAction("alumno");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ci.GetAlumns().Find(itemodel=>itemodel.CodAlumno== id));
        }

        // POST: Alumno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Alumn alumedit)
        {
            try
            {
                // TODO: Add update logic here
                ci.editalum(alumedit);

                return RedirectToAction("alumno");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            ci.eliminaralumno(id);

            return RedirectToAction("alumno");
        }

        // POST: Alumno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
