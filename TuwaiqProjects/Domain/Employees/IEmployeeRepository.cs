using TuwaiqProjects.Domain.Org;

namespace TuwaiqProjects.Domain.Employees;

public interface IEmployeeRepository
{
    Task AddAsync(Employee e);
    Task DeleteAsync(long id);
    Task UpdateAsync( Employee e);
    Task<Employee> GetByIdAsync(long id);
    Task<List<Employee>> GetAllAsync(string? filter);
}