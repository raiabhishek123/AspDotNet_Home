using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _db;

        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employeeRecord = _db.employees;
            return View(employeeRecord);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var res = _db.employees.Find(id);
            if (res == null)
            {
                return NotFound();
            }
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var res = _db.employees.Find(id);
            if (res == null)
            {
                return NotFound();
            }
            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.employees.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee deleted Suceesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
