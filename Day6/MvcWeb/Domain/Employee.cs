using System.ComponentModel.DataAnnotations;

namespace MvcWeb.Domain;

public class Employee
{
    [Range(1,int.MaxValue)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public bool IsActive { get; set; }
}