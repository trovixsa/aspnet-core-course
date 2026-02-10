using Day8.Domain.Employees;

namespace Day8.Inrastructure.Database;

public class EmployeeRepo : IEmployeeReposotiry
{
    private List<Employee> _employees = new List<Employee>();

    public EmployeeRepo()
    {
        _employees.Add(new Employee()
        {
            Id = 1,
            Name = "Abdullah Ali",
            Department = "IT"
        });
    }
    public List<Employee> GetAllEmployees()
    {
        return _employees;
    }

    public void Add(int id, string name, string departement)
    {
        // do the checks 
        _employees.Add(new Employee()
        {
            Id = id, 
            Name = name,
            Department = departement

        });

    }

    public Employee GetEmployeeById(int id)
    {
        
        return _employees.FirstOrDefault(e => e.Id == id);
        
    }
}