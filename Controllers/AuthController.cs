using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using todoV2.Services.Auth;
using todoV2.ViewModels;

namespace todoV2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(AuthController.Login));
        }

        public IActionResult Login()    
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthVM vm)
        {
            if (!(vm.username == vm.password || vm.username == "admin"))
            {
                return View();
            }

            _authService.setAuth(true);

            var temp = _authService.isAuth();
            
            return RedirectToAction(nameof(TodoController.Index), "Todo");
        }
    }
}
