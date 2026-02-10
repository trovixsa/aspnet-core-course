using Microsoft.AspNetCore.Mvc;
using MvcWeb.Application;
using MvcWeb.Domain;

namespace MvcWeb.Controllers;

// يجب انشاء هذا الكنترولر في مجلد Controllers
// يجب ان ينتهي الاسم بكلمة Controller

[Controller] // هذا attribute يحدد ان هذا class هو controller
[Route("api/[controller]")]
public class DepartmentsController : Controller
{
    // لانشاء endpoint يجب انشاء public method داخل الكنترولر
    // يجب ان تكون ال method public
    // سنقوم بتسميتها ب action method
    [HttpGet]
    public string GetDepartment()
    {
        return "Department Name: Computer Science";
    }

    [HttpGet("/department/{id?}")]
    public string GetDepartmentById(int id)
    {
        
        if (!ModelState.IsValid)
        {
            
        }
        return $"Department Info: {id}";
    }


    // show issue with complex types
    [HttpPost("/employee")]
    public object Create(Employee? employee)
    {
        if(ModelState.IsValid == false)
        {
            // handle the error

            List<string> errors = new List<string>();
            foreach (var item in ModelState.Values)
            {
                foreach (var itemError in item.Errors)
                {
                    errors.Add(itemError.ErrorMessage);
                }
            }

            return BadRequest(new
            {
                Success = false,
                Errors = errors
            });
            
        }
        

        
        return employee;
    }

    [NonAction]
    public string GetDepartmentByName(string name)
    {
        return "abc";
    }
}




