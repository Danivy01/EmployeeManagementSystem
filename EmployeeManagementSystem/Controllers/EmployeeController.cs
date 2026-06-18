using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers {
    public class EmployeeController : Controller {

        private static List<Employee> employees = new List<Employee> {
            new Employee { ID = 1, EmployeeID = "MA25318301", FullName = "Josephine Martinez", Department = "MITSD", Position = "Junior Programmer", DateHired = DateTime.Now.AddDays(15) },
            new Employee { ID = 2, EmployeeID = "MA25318310", FullName = "Joseph Angeles", Department = "MITSD", Position = "Senior Programmer", DateHired = DateTime.Now.AddDays(10) },
            new Employee { ID = 3, EmployeeID = "MA25318320", FullName = "Jose Del Pilar", Department = "MITSD", Position = "MIS Supervisor", DateHired = DateTime.Now.AddDays(20) },
            new Employee { ID = 4, EmployeeID = "MA25318330", FullName = "Josine Cruz", Department = "MITSD", Position = "Team Lead", DateHired = DateTime.Now.AddDays(25) }
        };

        [HttpGet]
        public IActionResult Index() {
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create() { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee) {
            employee.ID = employees.Count + 1;
            employees.Add(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID) {
            var emp = employees.FirstOrDefault(x => x.ID == ID);
            if (emp == null) {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee) {
            var emp = employees.FirstOrDefault(x => x.ID == employee.ID);

            if (emp == null) {
                return NotFound();
            }

            emp.EmployeeID = employee.EmployeeID;
            emp.FullName = employee.FullName;
            emp.Department = employee.Department;
            emp.Position = employee.Position;
            emp.DateHired = employee.DateHired;
            return RedirectToAction("Index");
        }
    }
}
