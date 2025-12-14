using Microsoft.AspNetCore.Mvc;
using todoV2.ViewModels;
using todoV2.data;
using todoV2.Mappers;
using todoV2.Services.SessionManager;
using todoV2.Filters;
using todoV2.Services.Auth;

namespace todoV2.Controllers
{
    public class TodoController : Controller
    {
        private readonly ISessionManagerService _sessionManager;
        private readonly IAuthService _authService;

        public TodoController(ISessionManagerService sessionManagerService, IAuthService auth)
        {
            this._sessionManager = sessionManagerService;
            this._authService = auth;
        }

        public IActionResult Index()
        {
            List<Todo> todos = _sessionManager.getFromSession<List<Todo>>("todos") ?? new List<Todo>();
            ViewBag.todos = todos;
            ViewBag.auth = _authService.isAuth();
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
                todo.id = todos.Any() ? todos.Max(t => t.id) + 1 : 1 ;
                todos.Add(todo);
                _sessionManager.addSession(todos, "todos");
            }
            else
            {
                todo.id = 1;
                todos.Add(todo);
                _sessionManager.addSession(todos, "todos");
            }
            return RedirectToAction(nameof(TodoController.Index));
        }

        [ServiceFilter(typeof(AuthFilter))]
        [HttpPost]
        public IActionResult DeleteTodo(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            List<Todo> todos = _sessionManager.getFromSession<List<Todo>>("todos") ?? new List<Todo>();
            Todo todo = todos.Find(t => t.id == id)!;
            if (todo == null)
            {
                return NotFound();
            }
            todos.Remove(todo);
            _sessionManager.addSession(todos, "todos");
            return RedirectToAction(nameof(TodoController.Index));
        }
    }
}
