﻿
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    { 
        /// <summary>
      /// Extension method to add core services to the dependecy injection container
      /// </summary>
      /// <param name="services"></param>
      /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            // To Do: Add services to the IOC container
            // Core services orthen inclued data access, caching and other low-level components
            services.AddTransient<IUsersService, UsersService>();

            services.AddScoped<IValidatorService, ValidatorService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            return services;
        }
    }
}
