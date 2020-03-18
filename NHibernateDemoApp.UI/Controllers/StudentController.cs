using NHibernateDemoApp.Data.Entity;
using NHibernateDemoApp.Data.Repository;
using System;
using System.Linq;
using System.Web.Mvc;
using NHibernateDemoApp.Data.Model;

namespace NHibernateDemoApp.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public StudentController()
        {
            _studentRepository = new StudentRepository();
        }

        // GET: Student
        public ActionResult Index()
        {
            var model = _studentRepository.All().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var entity = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                _studentRepository.Save(entity);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = _studentRepository.Get(id);
            var model=new StudentModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName =  entity.LastName
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var entity = new Student()
                {
                    Id =  model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                _studentRepository.Update(entity);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            _studentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}