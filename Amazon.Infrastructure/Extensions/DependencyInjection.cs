//using Amazon.Core.Contract.Services;
//using Amazon.Core.Interfaces;
//using Amazon.Infrastructure.Repositories;
//using Microsoft.Extensions.DependencyInjection;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Amazon.Infrastructure.Extensions
//{
//    public static class DependencyInjection
//    {
//        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
//        {
//            // Register Repositories
//            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//            services.AddScoped<IAuthRepository, AuthRepository>();

//            // Register Unit of Work
//            services.AddScoped<IUnitOfWork, UnitOfWork>();

//            //services.AddScoped<IAuthService, AuthService>();
//            //services.AddScoped<ITokenService, TokenService>();

//            return services;
//        }
//    }
//}
