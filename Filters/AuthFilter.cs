using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using todoV2.Controllers;
using todoV2.Services.Auth;

namespace todoV2.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        private readonly IAuthService _authService;

        public AuthFilter(IAuthService authService)
        {
            _authService = authService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_authService.isAuth())
            {
                context.Result = new RedirectToActionResult(
                    nameof(AuthController.Login), "Auth", null
                );
            }

            base.OnActionExecuting(context);
        }
    }
}
