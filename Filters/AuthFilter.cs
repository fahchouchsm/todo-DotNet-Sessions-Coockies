using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using todoV2.Controllers;
using todoV2.Services.Auth;

namespace todoV2.Filters
{
    public class AuthFilter: IAuthorizationFilter
    {
        private readonly IAuthService _authService;
        public AuthFilter(IAuthService authService) {
            this._authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        { 
            if(!_authService.isAuth())
            {
                 filterContext.Result = new RedirectToActionResult(nameof(AuthController.Login), "Auth", null);
            }
        }
    }
}
