using Microsoft.AspNetCore.Mvc;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;
using MyFridge_Interface_WebAPI.Service.Data.Interface;

namespace MyFridge_Interface_WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapperService _map;
        private readonly ILogger<RecipeController> _log;

        public RecipeIngredientsController(IDataService dataService, IMapperService map, ILogger<RecipeController> log)
        {
            _dataService = dataService;
            _map = map;
            _log = log;
        }
        [HttpPost]
        public async Task<JsonResult> UpsertAsync(int id, [FromBody]IngredientAmountCto dto)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            bool success = await _dataService.Recipes.AddIngredientAmountAsync(id, _map.ToIngredientAmountDto(from: dto));

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(dto);
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync(int id, int iaId)
        {
            RecipeDto? recipe = await _dataService.Recipes.GetAsync(id);
            if (recipe == null) return new JsonResult(NotFound());

            IngredientAmountDto? ingredientAmount = recipe.IngredientAmounts.FirstOrDefault(ia => ia.Id == iaId);
            if (ingredientAmount == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToIngredientAmountCto(from: ingredientAmount));
        }
        [HttpGet]
        public async Task<JsonResult> GetAllAsync(int id)
        {
            RecipeDto? recipe = await _dataService.Recipes.GetAsync(id);
            if (recipe == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToRecipeCto(from: recipe).IngredientAmounts);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteAsync(int id, int iaId)
        {
            bool success = await _dataService.Recipes.RemoveIngredientAmountAsync(id, iaId);

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(NoContent());
        }
    }
}