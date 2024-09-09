using HsptMS.Abstract;
using HsptMS.Abstraction;
using HsptMS.Data.DTO;
using HsptMS.Data.Models;
using HsptMS.Data.ViewModels;
using HsptMS.Servises;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HsptMS.Controllers
{

    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IEmailService emailService,
             IUserService userService
            )
        {
            _authenticationService = authenticationService;
            _emailService = emailService;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            _authenticationService.Signup(user);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            User? user = _userService.GetUser(model.EmailOrUserName, model.PassWord);
            if (user != null)
            {
                int expiryTimeFram = _;

                List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.EmailOrUserName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Country, "Pakistan"),
                new Claim(ClaimTypes.Sid,user.UserId.ToString())

            };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = model.KeepLoggedIn,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(expiryTimeFram)
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);



                ViewData["ValidateMessage"] = "User not found";
                return View();
            }

            public IActionResult LogOut()
            {
                _authenticationService.LogOutAsync();
                return RedirectToAction("Login", "Authentication");
            }
        }
    } 
}