using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace todoV2.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddTodo(Todo vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", vm);
            }

            List<Todo> todos = new List<Todo>();
            var json = HttpContext.Session.GetString("todos");
            if (json != null)
            {
              todos = JsonSerializer.Deserialize<List<Todo>>(json);
                todos.Add(vm);
                AddToSession("todos", todos);
            }
            else
            {
                todos.Add(vm);
                AddToSession("todos", todos);
                
            }
             return RedirectToAction("Index");
        }


        private void AddToSession (string name, List<Todo> todos)
        {
            HttpContext.Session.SetString(name, JsonSerializer.Serialize(todos));
        }
    }
}
