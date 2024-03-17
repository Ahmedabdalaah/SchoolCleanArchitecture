using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Infrustructure.Abstract;
using School.Infrustructure.InfrustructureBases;
using School.Infrustructure.Repositories;

namespace School.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
    {
            services.AddTransient<IStudentRepository , StudentRepository> ();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
