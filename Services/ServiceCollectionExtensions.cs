using Microsoft.Extensions.DependencyInjection;
using Ads.Services;

namespace Ads.Extensions
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
            services.AddScoped<DocumentoService>();
            services.AddScoped<MatrizCurricularService>();

            return services;
        }
    }
}
