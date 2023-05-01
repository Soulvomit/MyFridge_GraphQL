using Microsoft.EntityFrameworkCore;
using MyFridge_Interface_GraphQL.Service.Data;
using MyFridge_Interface_GraphQL.Service.Data.Interface;
using MyFridge_Interface_GraphQL.Service.Mapper;
using MyFridge_Interface_GraphQL.Service.Mapper.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataModel;
using MyFridge_Interface_GraphQL.Query;
using MyFridge_Interface_GraphQL.Service.Mapper.UoW.Interface;
using MyFridge_Interface_GraphQL.Service.Mapper.UoW;
using MyFridge_Interface_GraphQL.Service.Data.UoW.Interface;
using MyFridge_Interface_GraphQL.Service.Data.UoW;

namespace MyFridge_Interface_GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //add services to the container
            //add graphql service
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<QueryQL>();
            //add db context service
            builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options
                                                .UseLazyLoadingProxies(true)
                                                .UseInMemoryDatabase("InMemoryDatabase"));
            //add mapper service
            builder.Services.AddSingleton<IMapperUoW, MapperUoW>();
            //add unit of work service
            builder.Services.AddScoped<IDataServiceUoW, DataServiceUoW>();

            var app = builder.Build();

            app.MapGraphQL();

            app.Run();
        }
    }
}