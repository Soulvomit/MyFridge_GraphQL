using Microsoft.AspNetCore.Mvc;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;
using MyFridge_Interface_WebAPI.Service.Data.Interface;

namespace MyFridge_Interface_WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccountIngredientsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapperService _map;
        private readonly ILogger<UserAccountController> _log;

        public UserAccountIngredientsController(IDataService dataService, IMapperService map, ILogger<UserAccountController> log)
        {
            _dataService = dataService;
            _map = map;
            _log = log;
        }

        [HttpPost]
        public async Task<JsonResult> UpsertAsync(int id, [FromBody] IngredientAmountCto dto)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            bool success = await _dataService.Users.AddIngredientAmountAsync(id, _map.ToIngredientAmountDto(from: dto));

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(dto);
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync(int id, int ingredientAmountId)
        {
            UserAccountDto? user = await _dataService.Users.GetAsync(id);

            if (user == null) return new JsonResult(NotFound());

            IngredientAmountDto? ingredientAmount = user.IngredientAmounts
                .FirstOrDefault(ingredientAmount => ingredientAmount.Id == ingredientAmountId);
            
            if (ingredientAmount == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToIngredientAmountCto(from: ingredientAmount));
        }
        [HttpGet]
        public async Task<JsonResult> GetAllAsync(int id)
        {
            UserAccountDto? user = await _dataService.Users.GetAsync(id);

            if (user == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToUserAccountCto(from: user).IngredientAmounts);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteAsync(int id, int ingredientAmountId, float removeAmount, bool forceRemove = true)
        {
            bool success = 
                await _dataService.Users.RemoveAmountAsync(id, ingredientAmountId, removeAmount, forceRemove);

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(NoContent());
        }
    }
} 