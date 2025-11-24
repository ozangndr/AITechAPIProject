using AITech.DataAccess.Repositories.AboutItemRepositories;
using AITech.DataAccess.Repositories.AboutRepositories;
using AITech.DataAccess.Repositories.BannerRepositories;
using AITech.DataAccess.Repositories.CategoryRepositories;
using AITech.DataAccess.Repositories.ChooseRepositories;
using AITech.DataAccess.Repositories.FAQRepositories;
using AITech.DataAccess.Repositories.FeatureRepositories;
using AITech.DataAccess.Repositories.ProjectRepositories;
using AITech.DataAccess.Repositories.SocialRepositories;
using AITech.DataAccess.Repositories.TestimonialRepositories;
using AITech.DataAccess.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DataAccess.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutItemRepository, AboutItemRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IChooseRepository, ChooseRepository>();
            services.AddScoped<IFAQRepository, FAQRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
