using Microsoft.EntityFrameworkCore;
using MyFridge_Interface_GraphQL.Service.Data.Abstract;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataRepository;

namespace MyFridge_Interface_GraphQL.Service.Data
{
    public class IngredientAmountService : DataService<IngredientAmountDto>
    {
        public IngredientAmountService(IDbContextFactory<ApplicationDbContext> contextFactory, ILoggerFactory logFactory)
            : base(contextFactory, logFactory)
        {
            Repository = new IngredientAmountDataRepository(_contextFactory.CreateDbContext(), _log);
        }
    }
}