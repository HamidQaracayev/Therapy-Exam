using Microsoft.Extensions.DependencyInjection;
using Therapy.Business.Services.Implementations;
using Therapy.Business.Services.Interfaces;

namespace Therapy.Business;

public static class ServiceRegistration
{
    public static void AddService(this IServiceCollection service)
    {
        service.AddScoped<ITherapistService, TherapistService>();
        service.AddScoped<IAccountService, AccountService>();
    }
}
