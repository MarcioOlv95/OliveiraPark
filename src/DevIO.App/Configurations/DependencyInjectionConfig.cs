using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Interfaces.Service;
using DevIo.Business.Notificacoes;
using DevIo.Business.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ParkContext>();
            services.AddScoped<IAvulsoRepository, AvulsoRepository>();
            services.AddScoped<IPrecoRepository, PrecoRepository>();
            services.AddScoped<IMensalRepository, MensalRepository>();

            services.AddScoped<IAvulsoService, AvulsoService>();
            services.AddScoped<IPrecoService, PrecoService>();
            services.AddScoped<IMensalService, MensalService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
