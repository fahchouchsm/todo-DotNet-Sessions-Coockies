using Microsoft.AspNetCore.Mvc;
using todoV2.Constant;


namespace todoV2.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Toggle()
        {
            var theme = Request.Cookies[CoockiesSessionsKeys.themeCoockie] ?? "light";
     
            string toggledTheme;
            if(theme == "light")
            {
                toggledTheme = "dark";
            } else
            {
                toggledTheme = "light";
            }
            Response.Cookies.Append(CoockiesSessionsKeys.themeCoockie, toggledTheme);
            

            return Ok();
        }
    }
}
