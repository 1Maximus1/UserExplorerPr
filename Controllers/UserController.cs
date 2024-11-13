using Microsoft.AspNetCore.Mvc;

namespace UserExplorer.Controllers
{
    public class UserController : Controller
    {
        private readonly Dictionary<string, string> _users = new()
        {
            { "Oleg", "Oleg is a software developer from New York." },
            { "Taras", "Taras is a graphic designer from San Francisco." },
            { "Nikita", "Nikita is a data analyst from Chicago." }
        };

        [HttpGet]
        public IActionResult Index(string name, string color)
        {
            string message;
            if (string.IsNullOrEmpty(name))
            {
                message = "User name not specified.";
            }
            else if (_users.ContainsKey(name))
            {
                message = _users[name];
            }
            else
            {
                message = "User not found.";
            }

            ViewData["Message"] = message;
            ViewData["Color"] = color ?? "black";

            return View();
        }
    }
}
