using Martins.Infrastructure.DBConfiguration.EFCore;
using Martins.Infrastructure.Interfaces.Repositories.Domain;
using Martins.Infrastructure.Interfaces.Repositories.Standard;
using Martins.Infrastructure.Repositories.Domain.EFCore;
using Martins.Infrastructure.Repositories.Standard.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Martins.Infrastructure.IoC.ORMs.EFCore
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();

            return services;
        }
    }
}
