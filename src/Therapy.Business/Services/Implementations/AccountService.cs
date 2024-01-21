using Microsoft.AspNetCore.Identity;
using Therapy.Business.CustomExceptions;
using Therapy.Business.Services.Interfaces;
using Therapy.Business.ViewModel;
using Therapy.Core.Models;

namespace Therapy.Business.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _usermanager;

    private readonly SignInManager<AppUser> _signinmanager;
    public AccountService(UserManager<AppUser> usermanager, SignInManager<AppUser> signinmanager)
    {
        _usermanager = usermanager;
        _signinmanager = signinmanager;
    }

    public async Task Login(AdminLoginViewModel vm)
    {
        AppUser admin = null;

        admin = await _usermanager.FindByNameAsync(vm.Username);
        if (admin == null)
        {
            throw new UsernameIsNotValid("Username", "Username or password is wrong");
        }
        var result = await _signinmanager.PasswordSignInAsync(admin, vm.Password, false, false);
        if (!result.Succeeded)
        {
            throw new PasswordIsNotValid("Password", "Username or password is wrong");
        }
    }

    public async Task Logout()
    {
        await _signinmanager.SignOutAsync();
    }
}
