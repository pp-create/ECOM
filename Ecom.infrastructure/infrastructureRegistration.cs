using Ecom.core.interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using Ecom.infrastructure.Repositries;
using Ecom.infrastructure.Repositries.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure
{
 public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructurConfiguration(this IServiceCollection services,IConfiguration Configuration)
    {
         
           

      
            services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositry<>));
            //services.AddScoped<IcategoryRepositry, CategoryRepositry>();
            //services.AddScoped<IproductRepositry, productRepositry>();
            //services.AddScoped<IPhoto, PhotoRepositry>();
            services.AddScoped<IunitofWork, Unitofwork>();
            services.AddSingleton<IImagemanagementService, ImageManagementService>();
            services.AddSingleton<IFileProvider>(
      new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
  );
            //DATADABE
            services.AddDbContext<AppDBcontext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            return services;

    }
    
    }
}
