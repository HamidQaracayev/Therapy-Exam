using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Therapy.Business.CustomExceptions;
using Therapy.Business.Services.Interfaces;
using Therapy.Business.ViewModel;
using Therapy.Core.Models;

namespace Therapy.UI.Areas.manage.Controllers;

[Area("manage")]
public class AccountController : Controller
{
    private readonly IAccountService _accountservice;
    private readonly RoleManager<IdentityRole> _rolemanager;
    private readonly UserManager<AppUser> _usermanager;
    public AccountController(IAccountService accountservice, RoleManager<IdentityRole> rolemanager, UserManager<AppUser> usermanager)
    {
        _accountservice = accountservice;
        _rolemanager = rolemanager;
        _usermanager = usermanager;
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AdminLoginViewModel vm)
    {
        if (!ModelState.IsValid) { return View(); }
        try
        {
            await _accountservice.Login(vm);
        }
        catch (UsernameIsNotValid ex)
        {
            ModelState.AddModelError(ex.PropertyName, ex.Message);
            return View();
        }
        catch (PasswordIsNotValid ex)
        {
            ModelState.AddModelError(ex.PropertyName, ex.Message);
            return View();
        }
        return RedirectToAction("Index", "Therapist");
    }
    public async Task<IActionResult> Logout()
    {
        await _accountservice.Logout();
        return RedirectToAction("Login", "Account");
    }
    public async Task<IActionResult> CreateRole()
    {
        IdentityRole role1 = new IdentityRole("SuperAdmin");
        IdentityRole role2 = new IdentityRole("Admin");
        IdentityRole role3 = new IdentityRole("Member");

        await _rolemanager.CreateAsync(role1);
        await _rolemanager.CreateAsync(role2);
        await _rolemanager.CreateAsync(role3);
        return Ok("Rollar yarandi");
    }
    public async Task<IActionResult> CreateAdmin()
    {
        var admin = new AppUser
        {
            FullName = "Hamid Qaracayev",
            UserName = "admin",
        };

        await _usermanager.CreateAsync(admin, "Admin123@");
        await _usermanager.AddToRoleAsync(admin, "Admin");
        return Ok("Admin Yarandi");
    }
}
