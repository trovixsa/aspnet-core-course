using ModelBindSample.Domain;

namespace ModelBindSample.Infrastructure.Database;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
    int Add( string name, int age, DateTime joinDate);
    int Add(int id, string name, int age, DateTime joinDate);
    Employee Update(Employee employee);
    void Delete(int id);
}