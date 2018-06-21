using ArticleApi.Service.DAL;
using ArticleApi.Service.DAL.Interfaces;
using ArticleApi.Service.Infrastructure;
using ArticleApi.Service.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace ArticleApi.Service.Controllers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // services.AddTransient<ITopicAreaService, TopicAreaService>();
            RegisterDataAccessComponents(services);
            RegisterRepositories(services);
            RegisterInfrastructureServices(services);

            return services;
        }

        private static void RegisterDataAccessComponents(IServiceCollection services)
        {

            services.AddTransient<IDbConnection>(conn => new SqlConnection("Server=.\\SQLEXPRESS;Database=NewsArticleRepositoryDb;Integrated Security=SSPI"));

            services.AddTransient<IArticleRepositoryConnection, ArticleRepositoryConnection>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDalSession, DalSession>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private static void RegisterInfrastructureServices(IServiceCollection services)
        {

            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<ILogInService, LogInService>();
        }
    }
}
