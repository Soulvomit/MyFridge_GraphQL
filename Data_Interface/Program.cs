using Data_Interface.Mutation;
using Data_Interface.Mutation.Base;
using Data_Interface.Query;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Interface.Subscription.Base;
using Data_Library.DataContext;

namespace Data_Interface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //add services to the container
            //add db context service
            builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(optionsBuilder => 
                ApplicationDbContext.ConfigureOptions(optionsBuilder));

            //add graphql services
            builder.Services
                .AddGraphQLServer()
                    .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
                    .AddQueryType<QueryQL>()
                    .AddMutationType<MutationQL>()
                    .AddTypeExtension<AddressQuery>()
                    .AddTypeExtension<AdminQuery>()
                    .AddTypeExtension<GroceryQuery>()
                    .AddTypeExtension<IngredientAmountQuery>()
                    .AddTypeExtension<IngredientQuery>()
                    .AddTypeExtension<OrderQuery>()
                    .AddTypeExtension<RecipeQuery>()
                    .AddTypeExtension<UserQuery>()
                    .AddTypeExtension<AddressMutation>()
                    .AddTypeExtension<AdminMutation>()
                    .AddTypeExtension<GroceryMutation>()
                    .AddTypeExtension<IngredientAmountMutation>()
                    .AddTypeExtension<IngredientMutation>()
                    .AddTypeExtension<OrderMutation>()
                    .AddTypeExtension<RecipeMutation>()
                    .AddTypeExtension<UserMutation>()
                    .AddProjections()
                    .AddFiltering()
                    .AddSorting();
                    
            //add mapper service
            builder.Services.AddSingleton<IMapperUoW, MapperUoW>();

            var app = builder.Build();

            app.UseWebSockets();

            app.MapGraphQL();

            app.Run();
        }
    }
}