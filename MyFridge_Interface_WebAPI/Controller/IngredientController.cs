using Microsoft.AspNetCore.Mvc;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;
using MyFridge_Interface_WebAPI.Service.Data.Interface;

namespace MyFridge_Interface_WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapperService _map;
        private readonly ILogger<IngredientController> _log;

        public IngredientController(IDataService dataService, IMapperService map, ILogger<IngredientController> log)
        {
            _dataService = dataService;
            _map = map;
            _log = log;
        }
        [HttpPost]
        public async Task<JsonResult> UpsertAsync([FromBody] IngredientCto dto)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            if (dto.Id == 0) await _dataService.Ingredients.CreateAsync(_map.ToIngredientDto(from: dto));
            else
            {
                bool success = await _dataService.Ingredients.UpdateAsync(_map.ToIngredientDto(from: dto));

                if (!success) return new JsonResult(NotFound());
            }

            await _dataService.CompleteAsync();

            return new JsonResult((dto));
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync(int id)
        {
            IngredientDto? ingredient = await _dataService.Ingredients.GetAsync(id);

            if (ingredient == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToIngredientCto(from: ingredient));
        }
        [HttpGet()]
        public async Task<JsonResult> GetAllAsync()
        {
            List<IngredientCto> dtos = new List<IngredientCto>();
            List<IngredientDto> ingredients = await _dataService.Ingredients.GetAllAsync();

            foreach (IngredientDto ingredient in ingredients)
            {
                dtos.Add(_map.ToIngredientCto(from: ingredient));
            }

            return new JsonResult(dtos);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            bool success = await _dataService.Ingredients.DeleteAsync(id);

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(NoContent());
        }
    }
}
