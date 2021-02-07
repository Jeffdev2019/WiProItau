using CotacaoMoeda.Domain.CSV;
using CotacaoMoeda.Domain.Interfaces.Model;
using CotacaoMoeda.Domain.Interfaces.CSV;
using CotacaoMoeda.Domain.Interfaces.Service;
using CotacaoMoeda.Domain.Model;
using CotacaoMoeda.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CotacaoMoeda.API.Configuration
{
    public static class ConfigurationDependencyInjectionExtension
    {
        public static void ConfigurationDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IMoeda, Moeda>();
            services.AddTransient<IMoedaService, MoedaService>();
            services.AddTransient<IMoedaCSV, MoedaCSV>();
        }
    }
}
