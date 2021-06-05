using Library.BLL.Services;
using Library.DAL.Entities;
using Library.DAL.QueryBuilders;
using Library.DAL.Services;
using Library.DAL.Stores;
using Microsoft.Extensions.DependencyInjection;
using UtilityServices.Interfaces;
using UtilityServices.Services;

namespace Library.API.Configs
{
    public static class DIConfig
    {
        public static void RegisterInjections(this IServiceCollection services)
        {

            services.AddScoped<IImageUploadService, ImageUploadService>();
            services.AddScoped<IDocumentUploadService, DocumentUploadService>();

            services.AddScoped<IDbTransactionService, DbTransactionService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPagingService<Document>, PagingService<Document>>();
            services.AddScoped<IPagingService<QuestionAnswer>, PagingService<QuestionAnswer>>();
            services.AddScoped<IPagingService<Udk>, PagingService<Udk>>();

            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
            services.AddScoped<IUdkService, UdkService>();
            services.AddScoped<IPublicationPeriodService, PublicationPeriodService>();


            services.AddScoped<ISectionStore, SectionStore>();
            services.AddScoped<IAuthorStore, AuthorStore>();
            services.AddScoped<IDocumentStore, DocumentStore>();
            services.AddScoped<IAuthorDocumentStore, AuthorDocumentStore>();
            services.AddScoped<IUserStore, UserStore>();
            services.AddScoped<IQuestionAnswerStore, QuestionAnswerStore>();
            services.AddScoped<IUdkStore, UdkStore>();
            services.AddScoped<IPublicationPeriodsStore, PublicationPeriodsStore>();
            //services.AddScoped<INewsRepository, NewsRepository>();

            services.AddScoped<IDocumentQueryBuilder, DocumentQueryBuilder>();
            services.AddScoped<ISectionQueryBuilder, SectionQueryBuilder>();

            //services.AddHostedService<ExpiryTimeService>();

            //services.AddScoped<CustomExceptionFilterAttribute>();
        }
    }
}
