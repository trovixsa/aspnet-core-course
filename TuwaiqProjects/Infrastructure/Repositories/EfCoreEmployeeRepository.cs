using Microsoft.EntityFrameworkCore;
using TuwaiqProjects.Domain.Employees;
using TuwaiqProjects.Exceptions;
using TuwaiqProjects.Infrastructure.Database;

namespace TuwaiqProjects.Infrastructure.Repositories;

public class EfCoreEmployeeRepository : IEmployeeRepository
{
    private readonly TuwaiqDbContext _context;
    public EfCoreEmployeeRepository(TuwaiqDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Employee e)
    {
        _context.Employees.Add(e);
        _context.SaveChanges();
    }

    public async Task DeleteAsync(long id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }

    public async Task UpdateAsync(Employee e)
    {
        var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == e.Id);
        if (emp != null)
        {
            emp.Name = e.Name;

        }
        _context.SaveChanges();
    }

    public async Task<Employee> GetByIdAsync(long id)
    {
        
        var result = _context.Employees.FirstOrDefault(e => e.Id == id);
        if (result == null)
        {
            throw new EntityNotFoundException($"no entity with Id {id}");
        }
        return result;
    }

    public async Task<List<Employee>> GetAllAsync(string? filter, int pageIndex, int pageSize)
    {
        if (string.IsNullOrEmpty(filter))
        {
           
            

            return _context.Employees.Include(e => e.Department).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        return _context.Employees.Include(e => e.Department).Where(e => e.Name.Contains(filter)).ToList();
    }
}
