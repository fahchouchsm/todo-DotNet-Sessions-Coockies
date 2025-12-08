using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using todoV2.ViewModels;
using todoV2.data;
using todoV2.Mappers;
using todoV2.Services;
using System.Diagnostics;

namespace todoV2.Controllers
{
    public class TodoController : Controller
    {
        private readonly ISessionManagerService _sessionManager;

        public TodoController(ISessionManagerService sessionManagerService)
        {
            this._sessionManager = sessionManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddTodo(TodoAddVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", vm);
            }
            List<Todo> todos = new List<Todo>();
            Todo todo = TodoMapper.getTodoFromTodoAddVM(vm);

            var json = HttpContext.Session.GetString("todos");
            if (json != null)
            {
                todos = _sessionManager.getFromSession<List<Todo>>("todos")!;
                todos.Add(todo);
            }
            else
            {
                todos.Add(todo);
                _sessionManager.addSession(todos, "todos");
            }
            return RedirectToAction("Index");
        }
    }
}
