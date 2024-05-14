using Examen.ApplicationCore.Domain;
using Examen.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Web.Controllers
{
    public class PrestationController : Controller
    {
        IUnitOfWork unitOfWork;
        IService<Prestation> prestationService;
        IWebHostEnvironment webHostEnvironment;
        IService<Prestataire> prestataireService;
        public PrestationController(IUnitOfWork unitOfWork, IService<Prestation> prestationService, IWebHostEnvironment webHostEnvironment, IService<Prestataire> prestataireService)
        {
            this.unitOfWork = unitOfWork;
            this.prestationService = prestationService;
            this.webHostEnvironment = webHostEnvironment;
            this.prestataireService = prestataireService;
        }
        // GET: PrestationController
        //make index show the prestations for the prestataire whose id is passed as parameter

        public ActionResult Index(int id)
        {
            return View(prestataireService.GetById(id).Prestations);
        }

        // GET: PrestationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrestationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PrestationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestationController/Edit/5
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

        // GET: PrestationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestationController/Delete/5
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
