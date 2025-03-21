using HotelBookingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public AccountController(UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                             RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    // ========== LOGIN ==========
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Credenziali non valide.");
        return View();
    }

    // ========== LOGOUT ==========
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

    // ========== REGISTRAZIONE ==========
    
    [HttpGet]
    public IActionResult Register() => View();

    
    [HttpPost]
    public async Task<IActionResult> Register(string email, string password, string ruolo = "User")
    {
        var user = new ApplicationUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync(ruolo))
                await _roleManager.CreateAsync(new ApplicationRole { Name = ruolo });

            await _userManager.AddToRoleAsync(user, ruolo);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return RedirectToAction("Login"); 
    }
}
