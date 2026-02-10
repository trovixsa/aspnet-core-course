using Microsoft.AspNetCore.Mvc;
using MvcWeb.Application;

namespace MvcWeb.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            string name = "Abdullah"; // we get this from database

            var html = $@"
                <h1>asp.net core</h1>
                <br/>
                <p>Welcome {name} to the course</p>    
                <form method='post' action='/home/create'>
                    <input type='text' name='name' placeholder='Enter your name'/>
                    <button type='submit'>Submit</button>
                </form>
            ";
            //return Content(html, contentType: "text/html");
            return View("Index");

        }

        public IActionResult Create(string name)
        {
            return Content($"Hello {name} is created");
        }
    }
}
