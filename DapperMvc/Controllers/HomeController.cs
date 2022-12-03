using DapperMvc.Models;
using DapperMvc.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace DapperMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View(_studentService.GetStudents());
        }

        public IActionResult StudentDetails(Guid id)
        {
            var student = _studentService.GetStudentById(id);

            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            _studentService.CreateStudent(student);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var student = _studentService.GetStudentById(id);

            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            _studentService.UpdateStudent(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid id)
        {
            var student = _studentService.GetStudentById(id);

            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _studentService.DeleteStudent(id);

            return RedirectToAction("Index");
        }
    }
}
