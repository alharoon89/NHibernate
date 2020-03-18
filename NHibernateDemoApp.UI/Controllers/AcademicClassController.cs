using NHibernateDemoApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernateDemoApp.Data.Entity;

namespace NHibernateDemoApp.UI.Controllers
{
    public class AcademicClassController : Controller
    {
        private readonly ClassRepository _classRepository;

        public AcademicClassController()
        {
            _classRepository = new ClassRepository();
        }

        // GET: AcademicClass
        public ActionResult Index()
        {
            var model = _classRepository.All().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AcademicClass model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var entity = new AcademicClass()
                {
                    Name = model.Name,
                };
                _classRepository.Save(entity);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            var model = _classRepository.Get(id);
            return View(model);
        }

    }
}