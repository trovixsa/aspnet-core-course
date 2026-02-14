namespace TuwaiqProjects.Domain.Org;

public interface IDepartmentRepository
{
    Task AddAsync(Department d);
    Task DeleteAsync(long id);
    Task UpdateAsync(Department d);
    Task<Department> GetByIdAsync(long id);
    Task<List<Department>> GetAllAsync(string filter);
}