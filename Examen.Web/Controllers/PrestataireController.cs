using Examen.ApplicationCore.Domain;
using Examen.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class PrestataireController : Controller
    {
        IUnitOfWork unitOfWork;
        IService<Prestataire> prestataireService;
        IWebHostEnvironment webHostEnvironment;
        IService<Specialite> specialiteService;
        public PrestataireController(IUnitOfWork unitOfWork, IService<Prestataire> prestataireService, IWebHostEnvironment webHostEnvironment, IService<Specialite> specialiteService)
        {
            this.unitOfWork = unitOfWork;
            this.prestataireService = prestataireService;
            this.webHostEnvironment = webHostEnvironment;
            this.specialiteService = specialiteService;
        }
        // GET: PrestataireController
        public ActionResult Index()
        {
            return View(prestataireService.GetAll());
        }

        // GET: PrestataireController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestataireController/Create
        public ActionResult Create()
        {
            ViewBag.selectList = new SelectList(specialiteService.GetAll(), "Code", "Code");
            return View();
        }

        // POST: PrestataireController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestataire prestataire, IFormFile logo)
        {
            if(logo != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", logo.FileName);
                Stream stream = new FileStream(path, FileMode.Create);
                logo.CopyTo(stream);
                prestataire.PrestatairePhoto = logo.FileName;
            }
            prestataireService.Add(prestataire);
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult goToPrestations(int id)
        {
            return RedirectToAction("Index", "Prestation", new { id = id });
        }

        // GET: PrestataireController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestataireController/Edit/5
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

        // GET: PrestataireController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestataireController/Delete/5
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
