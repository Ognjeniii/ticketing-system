using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using ticketing_system.Models.User;

namespace ticketing_system.Filters
{
    public class SessionAuthFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;

            var path = httpContext.Request.Path.Value.ToLower();
            if (path.Contains("/login") 
                || path.Contains("/changepass") 
                || path.Contains("/sendmail") 
                || path.Contains("/forgetpass/checkcode"))
            {
                return;
            }

            var usernameSession = httpContext.Session.GetString("username");
            var userIdSession = httpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(usernameSession) || string.IsNullOrEmpty(userIdSession))
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }
    }
}
