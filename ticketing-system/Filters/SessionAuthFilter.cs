﻿using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Text.Json;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;

namespace ticketing_system.Filters
{
    public class SessionAuthFilter : IAsyncActionFilter
    {
        private readonly IUserService _userService;

        public SessionAuthFilter(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpContext = context.HttpContext;

            var path = httpContext.Request.Path.Value.ToLower();
            if (path.Contains("/login")
                || path.Contains("/changepass")
                || path.Contains("/sendmail")
                || path.Contains("/forgetpass/checkcode"))
            {
                await next();
                return;
            }

            var userStringSession = httpContext.Session.GetString("user_object");
            var userIdSession = httpContext.Session.GetString("user_id");

            if (string.IsNullOrEmpty(userStringSession) || string.IsNullOrEmpty(userIdSession))
            {
                // Request.Cookies - collection contains cookies received from the client, readonly
                var rememberMeCookie = httpContext.Request.Cookies["RememberMe"];
                var userIdCookie = httpContext.Request.Cookies["UserId"];

                // if user clicked "Remember me", we need to set sessions.
                if (!string.IsNullOrEmpty(rememberMeCookie) || !string.IsNullOrEmpty(userIdCookie))
                {
                    int userId = int.Parse(userIdCookie);
                    User user = await _userService.GetUserByIdAsync(userId);

                    if (user != null)
                    {
                        httpContext.Session.SetString("user_object", JsonSerializer.Serialize(user));
                        httpContext.Session.SetInt32("user_id", userId);

                        await next();
                        return;
                    }
                }

                context.Result = new RedirectToActionResult("Index", "Login", null);
                return;
            }

            await next();
        }
    }
}
