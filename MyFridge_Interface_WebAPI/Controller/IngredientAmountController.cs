using Microsoft.AspNetCore.Mvc;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;
using MyFridge_Interface_WebAPI.Service.Data.Interface;

namespace MyFridge_Interface_WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IngredientAmountController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapperService _map;
        private readonly ILogger<IngredientAmountController> _log;

        public IngredientAmountController(IDataService dataService, IMapperService map, ILogger<IngredientAmountController> log)
        {
            _dataService = dataService;
            _map = map;
            _log = log;
        }
        [HttpPost]
        public async Task<JsonResult> UpsertAsync([FromBody] IngredientAmountCto dto)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            if (dto.Id == 0) await _dataService.IngredientAmounts.CreateAsync(_map.ToIngredientAmountDto(from: dto));
            else
            {
                bool success = await _dataService.IngredientAmounts.UpdateAsync(_map.ToIngredientAmountDto(from: dto));

                if (!success) return new JsonResult(NotFound());
            }

            await _dataService.CompleteAsync();

            return new JsonResult(dto);
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync(int id)
        {
            IngredientAmountDto? ingredientAmount = await _dataService.IngredientAmounts.GetAsync(id);

            if (ingredientAmount == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToIngredientAmountCto(from: ingredientAmount));
        }
        [HttpGet]
        public async Task<JsonResult> GetAllAsync()
        {
            List<IngredientAmountCto> dtos = new List<IngredientAmountCto>();
            List<IngredientAmountDto> ingredientAmounts = await _dataService.IngredientAmounts.GetAllAsync();

            foreach (IngredientAmountDto ingredientAmount in ingredientAmounts)
            {
                dtos.Add(_map.ToIngredientAmountCto(from: ingredientAmount));
            }

            return new JsonResult(dtos);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            bool success = await _dataService.IngredientAmounts.DeleteAsync(id);

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(NoContent());
        }
    }
}
