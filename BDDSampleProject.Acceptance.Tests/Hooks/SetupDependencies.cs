using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace BDDSampleProject.Acceptance.Tests.Hooks
{
    public class SetupDependencies
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddCalculatorServices();

            return services;
        }
    }
}
