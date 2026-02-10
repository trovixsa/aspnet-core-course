using Day8.Domain.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Day8.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeReposotiry _employeeReposotiry;

        public EmployeesController(IEmployeeReposotiry employeeReposotiry)
        {
            _employeeReposotiry = employeeReposotiry;
        }

        public IActionResult Index()
        {
            var result = _employeeReposotiry.GetAllEmployees();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {
            _employeeReposotiry.Add(e.Id,e.Name,e.Department);
            return RedirectToAction("Index");
        }

        
        public IActionResult EmployeeDetails(int employeeId)
        {
            var emp = new Employee();

           
            
            var employee = _employeeReposotiry.GetEmployeeById(employeeId);
            
            return View(employee);
        }
    }
}
