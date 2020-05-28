using Martins.StartProject.Interfaces.Services.Domain;
using Martins.StartProject.Interfaces.Services.Standard;
using Martins.StartProject.Services.Domain;
using Martins.StartProject.Services.Standard;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Martins.StartProject.IoC.Services
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IEstadoService, EstadoService>();
        }
    }
}
