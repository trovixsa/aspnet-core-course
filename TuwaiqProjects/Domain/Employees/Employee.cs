using System.Text.Json.Serialization;
using TuwaiqProjects.Domain.Org;
using TuwaiqProjects.Shared;

namespace TuwaiqProjects.Domain.Employees;

public class Employee : EntityBase<long>
{

    /// <summary>
    /// Employee ID unique 
    /// </summary>
    public long EmployeeId { get; set; } 

    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public decimal Salary { get; set; }
    public long DepartmentId { get; set; }
    public long ManagerId { get; set; }
    public int JobTitleId { get; set; }


    /// <summary>
    /// Navigation Property to the Department the employee belongs to
    /// </summary>
    [JsonIgnore]
    public Department? Department { get; set; }

   
}