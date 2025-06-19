using Microsoft.Extensions.DependencyInjection;
using CrudVeiculos.Services;

namespace CrudVeiculos.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ServidorService>();
            services.AddScoped<CorpoDocenteService>();
            services.AddScoped<AlunoService>();
            services.AddScoped<DisciplinaService>();
            services.AddScoped<TccService>();

            return services;
        }
    }
}
