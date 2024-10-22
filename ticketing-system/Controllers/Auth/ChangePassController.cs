using Microsoft.AspNetCore.Mvc;
using ticketing_system.Models.User;
using ticketing_system.Models.User.Services.Abstraction;
using ticketing_system.Models.ViewModels;

namespace ticketing_system.Controllers.Auth
{
    public class ChangePassController : Controller
    {
        private readonly IUserService _userService;

        public ChangePassController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(ChangePassViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/ChangePass/Index.cshtml", data);
            }

            User user = await _userService.GetUserByUsernameAndPasswordAsync(data.Username, data.OldPassword);
            
            if (user == null)
            {
                ModelState.AddModelError("WrongData", "Wrong username or password!");
                return View("~/Views/ChangePass/Index.cshtml");
            }

            if (!data.NewPassword.Equals(data.RepeatedNewPassword))
            {
                ModelState.AddModelError("PasswordsNotEqaul", "New passwords are not equal!");
                //return View("~/Views/ChangePass/Index.cshtml"); // ovako se prikaže
                return RedirectToAction("Index"); // kada se na ovaj način vratim,
                                                  // iz nekog razloga, ne prikže se greška poruka
            }

            user.Username = data.Username;
            user.Password = data.NewPassword;
            User newUser = await _userService.UpdateUserAsync(user);

            return RedirectToAction("Index", "Base");
        }
    }
}
