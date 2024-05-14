using ExamenBI.Domain.Entities;
using ExamenBI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenBI.Web.Controllers
{
    public class TropheeController : Controller
    {
        readonly IServiceTrophee serviceTrophee;
        readonly IServiceEquipe serviceEquipe;

        public TropheeController(IServiceTrophee serviceTrophee, IServiceEquipe serviceEquipe)
        {
            this.serviceTrophee = serviceTrophee;
            this.serviceEquipe = serviceEquipe;
        }

        // GET: TropheeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TropheeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TropheeController/Create
        public ActionResult Create()
        {
            ViewBag.EquipeListe = new SelectList(serviceEquipe.GetAll(), "EquipeId", "NomEquipe");
            return View();
        }

        // POST: TropheeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trophee trophee)
        {
            serviceTrophee.Add(trophee);
            serviceTrophee.Commit();
            return View();
           
        }

        // GET: TropheeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TropheeController/Edit/5
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

        // GET: TropheeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TropheeController/Delete/5
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
