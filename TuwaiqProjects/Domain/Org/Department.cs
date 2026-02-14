using System.Text.Json.Serialization;
using TuwaiqProjects.Domain.Employees;

namespace TuwaiqProjects.Domain.Org;

public class Department : EntityBase<long>
{
    
    public string Name { get; set; }
    public long? ManagerId { get; set; }





    // navigation property to the manager of the department
    [JsonIgnore]
    public Employee? Manager { get; set; }

    // Navigation property to the employees that belong to this department
    public List<Employee> Employees { get; set; }
}