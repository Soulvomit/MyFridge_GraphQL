using Microsoft.AspNetCore.Mvc;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;
using MyFridge_Interface_WebAPI.Service.Data.Interface;

namespace MyFridge_Interface_WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapperService _map;
        private readonly ILogger<RecipeController> _log;
        public RecipeController(IDataService dataService, IMapperService map, ILogger<RecipeController> log)
        {
            _dataService = dataService;
            _map = map;
            _log = log;
        }
        [HttpPost]
        public async Task<JsonResult> UpsertAsync([FromBody] RecipeCto dto)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            if (dto.Id == 0) await _dataService.Recipes.CreateAsync(_map.ToRecipeDto(from: dto));
            else
            {
                bool success = await _dataService.Recipes.UpdateAsync(_map.ToRecipeDto(from: dto));

                if (!success) return new JsonResult(NotFound());
            }

            await _dataService.CompleteAsync();

            return new JsonResult(dto);
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync(int id)
        {
            RecipeDto? recipe = await _dataService.Recipes.GetAsync(id);

            if (recipe == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToRecipeCto(from: recipe));
        }
        [HttpGet]
        public async Task<JsonResult> GetFilteredAsync(string filter, int minLength = 2)
        {
            Func<RecipeDto, bool> filterFunc = recipe =>
            {
                bool nameMatches = recipe.Name.ToLower().Contains(filter.ToLower());
                
                bool ingredientNameMatches = recipe.IngredientAmounts.Any(ia =>
                    ia.Ingredient.Name.ToLower().Contains(filter.ToLower()));

                return nameMatches || ingredientNameMatches;
            };

            Func<RecipeDto, object> orderByFunc = recipe => recipe.Name;

            List<RecipeCto> dtos = new();
            IEnumerable<RecipeDto>? filteredRecipes = 
                await _dataService.Recipes.Query(filterFunc, orderByFunc, filter, minLength);

            if (filteredRecipes == null) return new JsonResult(NotFound());

            foreach (RecipeDto recipe in filteredRecipes)
            {
                dtos.Add(_map.ToRecipeCto(from: recipe));
            }
            return new JsonResult(dtos);
        }
        [HttpGet]
        public async Task<JsonResult> GetMakeableAsync(int userId)
        {
            UserAccountDto user = await _dataService.Users.GetAsync(userId);
            
            if (user == null) return new JsonResult(NotFound());

            Func<RecipeDto, bool> filterFunc = recipe =>
            {
                bool allIngredientsSatisfy = recipe.IngredientAmounts.All(recipeIngredient =>
                {
                    bool anyMatchingUserIngredient = user.IngredientAmounts.Any(userIngredient =>
                    {
                        bool anyMatchingIngredient = recipeIngredient.Ingredient.Id == userIngredient.Ingredient.Id;
                        bool anyMatchingAmount = recipeIngredient.Amount <= userIngredient.Amount;

                        return anyMatchingIngredient && anyMatchingAmount;
                    });
                    return anyMatchingUserIngredient;
                });
                return allIngredientsSatisfy;
            };

            Func<RecipeDto, object> orderByFunc = recipe => recipe.Name;

            List<RecipeCto> dtos = new();
            IEnumerable<RecipeDto>? makeableRecipes = await _dataService.Recipes.Query(filterFunc, orderByFunc);

            if (makeableRecipes == null) return new JsonResult(NotFound());

            foreach (RecipeDto recipe in makeableRecipes)
            {
                dtos.Add(_map.ToRecipeCto(from: recipe));
            }
            return new JsonResult(dtos);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllAsync()
        {
            List<RecipeCto> dtos = new List<RecipeCto>();
            List<RecipeDto> recipes = await _dataService.Recipes.GetAllAsync();

            foreach (RecipeDto recipe in recipes)
            {
                dtos.Add(_map.ToRecipeCto(from: recipe));
            }

            return new JsonResult(dtos);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            bool success = await _dataService.Recipes.DeleteAsync(id);

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(NoContent());
        }
    }
}