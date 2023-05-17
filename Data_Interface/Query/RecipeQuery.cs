using Client_Model.Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class RecipeQuery : QueryQL
    {
        public RecipeQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<RecipeQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<RecipeCto?> GetRecipeAsync(ApplicationDbContext context, RecipeCto cto)
        {
            if (cto == null) return null;

            RecipeDto? dto = await context.Recipes.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.Recipe.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RecipeCto?> GetRecipes(ApplicationDbContext context)
        {
            var mappingExpression = _map.Recipe.ProjectToCto();
            IQueryable<RecipeCto?> ctos = context.Recipes.Select(mappingExpression);

            return ctos;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<RecipeCto?>> GetMakeableRecipes(ApplicationDbContext context, UserAccountCto cto)
        {
            if (cto == null) return Enumerable.Empty<RecipeCto?>().AsQueryable();

            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);

            if (dto == null) return Enumerable.Empty<RecipeCto?>().AsQueryable();

            Dictionary<int, float> userIngredientAmounts = 
                dto.IngredientAmounts.ToDictionary(ia => ia.Ingredient.Id, ia => ia.Amount);

            Expression<Func<RecipeDto, bool>> filterExpression = recipe =>
                recipe.IngredientAmounts.All(recipeIngredient =>
                    userIngredientAmounts.ContainsKey(recipeIngredient.Ingredient.Id) &&
                    userIngredientAmounts[recipeIngredient.Ingredient.Id] >= recipeIngredient.Amount);

            Expression<Func <RecipeDto, RecipeCto>> mappingExpression = _map.Recipe.ProjectToCto();
            
            IQueryable<RecipeCto?> ctos = context.Recipes
                .Where(filterExpression)
                .Select(mappingExpression);

            return ctos;
        }
        //[UsePaging]
        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //public IQueryable<RecipeCto?> GetMakeableRecipes(ApplicationDbContext context, UserAccountCto cto)
        //{
        //    UserAccountDto? dto = context.Users.Find(cto.Id);

        //    if (dto == null) return null;

        //    Func<RecipeDto, bool> filterFunc = recipe =>
        //    {
        //        bool allIngredientsSatisfy = recipe.IngredientAmounts.All(recipeIngredient =>
        //        {
        //            bool anyMatchingUserIngredient = dto.IngredientAmounts.Any(userIngredient =>
        //            {
        //                bool anyMatchingIngredient = recipeIngredient.Ingredient.Id == userIngredient.Ingredient.Id;
        //                bool anyMatchingAmount = recipeIngredient.Amount <= userIngredient.Amount;

        //                return anyMatchingIngredient && anyMatchingAmount;
        //            });
        //            return anyMatchingUserIngredient;
        //        });
        //        return allIngredientsSatisfy;
        //    };

        //    var makeableRecipes = context.Recipes.Where(filterFunc);
        //    var mappingExpression = _map.Recipe.ProjectToCto();
        //    IQueryable<RecipeCto?> ctos = makeableRecipes.AsQueryable().Select(mappingExpression);

        //    return ctos;
        //}
    }
}