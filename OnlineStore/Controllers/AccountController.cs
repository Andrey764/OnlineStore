using System;
using System.Threading.Tasks;
using OnlineStore.View.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.DBClasses;
using OnlineStore.View.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.View.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _userManager.FindByNameAsync(model.Email) is null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Не правильный пароль");
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                return Redirect(model.ReturnUrl);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            const int minYear = 1899;
            var maxYear = DateTime.Now.Year - 1;

            if (model.DateOfBirth?.Year <= minYear)
            {
                ModelState.AddModelError("", $"Год должен быть больше {minYear}");
                return View(model);
            }

            if (model.DateOfBirth?.Year > maxYear)
            {
                ModelState.AddModelError("", $"Год должен быть меньше {maxYear + 1}");
                return View(model);
            }

            if (model.Age <= 0)
            {
                ModelState.AddModelError("", "Возраст не может быть меньше нуля или равен ему");
                return View(model);
            }

            if (model.NumberHouse <= 0)
            {
                ModelState.AddModelError("", "Номер квартиры не может быть меньше нуля или равен ему");
                return View(model);
            }

            if (!ModelState.IsValid)
                return View(model);

            var user = UserFactory.CreateUser(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}