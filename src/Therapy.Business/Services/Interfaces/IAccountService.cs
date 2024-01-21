using Therapy.Business.ViewModel;

namespace Therapy.Business.Services.Interfaces;

public interface IAccountService
{
    Task Login(AdminLoginViewModel vm);
    Task Logout();
}
