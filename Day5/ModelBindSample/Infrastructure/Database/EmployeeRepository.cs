using ModelBindSample.Domain;

namespace ModelBindSample.Infrastructure.Database;

public static class EmployeeRepository
{
    private static int _nextId = 4;

    private static List<Employee> _employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "Ahmad", Age = 30, JoinDate = new DateTime(2020, 1, 15) },
        new Employee { Id = 2, Name = "Omar", Age = 25, JoinDate = new DateTime(2021, 6, 1) },
        new Employee { Id = 3, Name = "Mohammad", Age = 28, JoinDate = new DateTime(2019, 11, 20) }
    };
    public static List<Employee> GetAll()
    {
        return _employees;
    }

    public static int Add( string name, int age, DateTime joinDate)
    {
        var newEmployee = new Employee
        {
            Id = _nextId++,
            Name = name,
            Age = age,
            JoinDate = joinDate
        };
        _employees.Add(newEmployee);

        // simulate database insert and return the new employee's ID
        return newEmployee.Id;
    }
    public static int Add(int id, string name, int age, DateTime joinDate)
    {
        // Check if an employee with the same ID already exists
        if (_employees.Any(e => e.Id == id))
        {
            throw new ArgumentException($"An employee with ID {id} already exists.");
        }
        var newEmployee = new Employee
        {
            Id = id,
            Name = name,
            Age = age,
            JoinDate = joinDate
        };
        _employees.Add(newEmployee);

        // simulate database insert and return the new employee's ID
        return id;
    }

    public static Employee Update(Employee employee)
    {
        // Find the existing employee by ID
        var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);

        if (existingEmployee != null)
        {
            existingEmployee.Age = employee.Age;
            existingEmployee.Name = employee.Name;
            existingEmployee.JoinDate = employee.JoinDate;

            // In a real implementation, you would save changes to the database here
        }
        return existingEmployee;
    }

    public static void Delete(int id)
    {
        // Find the employee by ID
        var employeeToDelete = _employees.FirstOrDefault(e => e.Id == id);
        if (employeeToDelete != null)
        {
            _employees.Remove(employeeToDelete);
            // In a real implementation, you would delete the record from the database here
        }

    }
}