using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Therapy.Core.Repositories.Interfaces;
using Therapy.Data.Repositories.Implementations;

namespace Therapy.Data
{
    public static class ServiceRegistration
    {
        public static void AddRepository(this IServiceCollection service) 
        {
            service.AddScoped<ITherapistRepository, TherapistRepository>();
        }

    }
}
