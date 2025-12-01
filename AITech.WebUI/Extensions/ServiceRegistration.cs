using AITech.WebUI.Services.AboutItemServices;
using AITech.WebUI.Services.AboutServices;
using AITech.WebUI.Services.BannerServices;
using AITech.WebUI.Services.CategoryServices;
using AITech.WebUI.Services.ChooseServices;
using AITech.WebUI.Services.FAQServices;
using AITech.WebUI.Services.FeatureServices;
using AITech.WebUI.Services.ProjectServices;
using AITech.WebUI.Services.SocialServices;
using AITech.WebUI.Services.TestimonialServices;

namespace AITech.WebUI.Extensions
{
    public static class ServiceRegistration
    {

        public static void AddUIServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAboutItemService, AboutItemService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IChooseService, ChooseService>();
            services.AddScoped<IFAQService, FAQService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISocialService, SocialService>();
            services.AddScoped<ITestimonialService, TestimonialService>();

        }
    }
}
