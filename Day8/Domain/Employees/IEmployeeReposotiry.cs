namespace Day8.Domain.Employees;

public interface IEmployeeReposotiry
{
    List<Employee> GetAllEmployees();
    void Add(int id, string name, string departement);
    Employee GetEmployeeById(int id);

}