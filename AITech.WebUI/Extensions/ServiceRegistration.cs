using AITech.WebUI.Services.CategoryServices;

namespace AITech.WebUI.Extensions
{
    public static class ServiceRegistration
    {

        public static void AddUIServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
