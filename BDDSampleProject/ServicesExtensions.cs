using BDDSampleProject.Operations;
using BDDSampleProject.Operations.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BDDSampleProject
{
    public static class ServicesExtensions
    {
        public static void AddCalculatorServices(this IServiceCollection services)
        {

            services.AddTransient<ICalculator, Calculator>();
            services.AddTransient<IAddOperation, AddOperation>();
            services.AddTransient<ISubstractOperation, SubstractOperation>();
            services.AddTransient<IMultiplyOperation, MultiplyOperation>();
            services.AddTransient<IDivideOperation, DivideOperation>();
            services.AddTransient<IOperation, AddOperation>();
            services.AddTransient<IOperation, SubstractOperation>();
            services.AddTransient<IOperation, MultiplyOperation>();
            services.AddTransient<IOperation, DivideOperation>();
        }
    }
}
