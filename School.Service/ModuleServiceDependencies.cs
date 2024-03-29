﻿using Microsoft.Extensions.DependencyInjection;
using School.Infrustructure.Abstract;
using School.Infrustructure.Repositories;
using School.Service.Abstracts;
using School.Service.Implementations;

namespace School.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
            services.AddTransient<IStudentService, StudentService>();
            return services;
        }
    }
}
