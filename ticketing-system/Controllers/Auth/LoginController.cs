﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;
using ticketing_system.ViewModels.Auth;

namespace ticketing_system.Controllers.Auth
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Login/Index.cshtml");
        }

        // metoda koja se pokreće prilikom klika na dugme "login"
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userService.GetUserByUsernameAndPasswordAsync(model.Username, model.Password);

                if (user != null)
                {
                    // ako je korisnik označio "Zapamti me"
                    if (model.RememberMe)
                    {
                        // Setujemo kukiS
                        Response.Cookies.Append("RememberMe", "true", new CookieOptions
                        {
                            Expires = DateTime.UtcNow.AddDays(30)
                        });

                        Response.Cookies.Append("UserId", user.UserId.ToString(), new CookieOptions
                        {
                            Expires = DateTime.UtcNow.AddDays(30)
                        });
                    }

                    // Setujemo sesije
                    HttpContext.Session.SetString("user_object", JsonSerializer.Serialize(user));
                    HttpContext.Session.SetInt32("user_id", user.UserId);

                    // Preusmerujemo korisnika na početnu stranicu // bilo Home, Base
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // ***OVO TREBA DA SE DODA U VIEW.
                    ModelState.AddModelError("invalid_login", "Invalid login attempt. Please check your email and password.");
                }
            }

            return View("~/Views/Login/Index.cshtml", model);
        }
    }
}
