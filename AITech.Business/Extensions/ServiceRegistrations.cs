using AITech.Business.Services.AboutItemServices;
using AITech.Business.Services.AboutServices;
using AITech.Business.Services.CategoryServices;
using AITech.Business.Services.ProjectServices;
using AITech.Business.Services.TestimonialServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {            
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAboutItemService, AboutItemService>();
        }
    }
}
