using ExamenBI.Domain.Entities;
using ExamenBI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenBI.Web.Controllers
{
    public class EquipeController : Controller
    {

        readonly IServiceEquipe serviceEquipe;

        public EquipeController(IServiceEquipe serviceEquipe)
        {
            this.serviceEquipe = serviceEquipe;
        }

        // GET: EquipeController


        public ActionResult Index(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
                return View(serviceEquipe.GetMany(p => p.NomEquipe.Contains(filter)));
            return View(serviceEquipe.GetAll());
      
        }

        // GET: EquipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipe equipe ,IFormFile file)
        {
            //ajout Image dans la BDD
            equipe.Logo = file.FileName;
            serviceEquipe.Add(equipe);
            serviceEquipe.Commit();
            // ajout image dans le dossier
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
               file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return RedirectToAction("Index");
        }

        // GET: EquipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
