using Microsoft.AspNetCore.Mvc;
using TuwaiqProjects.Domain.Employees;
using TuwaiqProjects.Infrastructure.Database;

namespace TuwaiqProjects.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly TuwaiqDbContext _context;

        public EmployeeController(IEmployeeRepository employeeRepository, TuwaiqDbContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }


        [HttpGet("/Employee/FilterEmployees")]
        public async Task<List<Employee>> FilterEmployees(string filter)
        {
            return _context.Employees.ToList();
            return  await _employeeRepository.GetAllAsync(filter);


        }

        public async Task<IActionResult> Index(string? filter)
        {
            var result = await _employeeRepository.GetAllAsync(filter);
            return View(result);
        }

        public IActionResult Details(int id)
        {
            // Logic to retrieve employee details by id
            return View();
        }

        public IActionResult Edit()
        {
            return View(); 

        }

        public IActionResult Add()
        {
            return View();

        }
    }
}
