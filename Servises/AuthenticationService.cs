using HsptMS.Data.Models;
using HsptMS.Data.ViewModels;
using HsptMS.Abstraction;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IConfigurationService _configurationService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly EmailService _emailService;

    public AuthenticationService(
        IUserService userService,
        IConfigurationService configurationService,
        IHttpContextAccessor httpContextAccessor,
        EmailService emailService)
    {
        _userService = userService;
        _configurationService = configurationService;
        _httpContextAccessor = httpContextAccessor;
        _emailService = emailService;
    }

    public async Task<bool> LoginAsync(LoginVM model)
    {
        User? user = _userService.GetUser(model.EmailOrUserName, model.PassWord);

        if (user != null)
        {
            int expiryTimeFram = _configurationService.GetExpiryTimeframeInMinutes();

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.EmailOrUserName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Country, "Pakistan"),
                new Claim(ClaimTypes.Sid, user.UserId.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = model.KeepLoggedIn,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(expiryTimeFram)
            };

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);

            return true;
        }

        return false;
    }

    public async Task LogOutAsync()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public void Signup(User user)
    {
        _userService.Register(user);
    }
}
