using Microsoft.AspNetCore.Mvc;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;
using MyFridge_Interface_WebAPI.Service.Data.Interface;

namespace MyFridge_Interface_WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapperService _map;
        private readonly ILogger<AddressController> _log;

        public AddressController(IDataService dataService, IMapperService map, ILogger<AddressController> log)
        {
            _dataService = dataService;
            _map = map;
            _log = log;
        }

        [HttpPost]
        public async Task<JsonResult> UpsertAsync([FromBody] AddressCto dto)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            if (dto.Id == 0) await _dataService.Addresses.CreateAsync(_map.ToAddressDto(from: dto));
            else
            {
                bool success = await _dataService.Addresses.UpdateAsync(_map.ToAddressDto(from: dto));

                if (!success) return new JsonResult(NotFound());
            }

            await _dataService.CompleteAsync();

            return new JsonResult(dto);
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync(int id)
        {
            AddressDto? address = await _dataService.Addresses.GetAsync(id);

            if (address == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToAddressCto(from: address));
        }
        [HttpGet]
        public async Task<JsonResult> GetAllAsync() 
        {
            List<AddressCto> dtos = new List<AddressCto>();
            List<AddressDto> addresses = await _dataService.Addresses.GetAllAsync();

            foreach(AddressDto address in addresses)
            {
                dtos.Add(_map.ToAddressCto(from: address)!);
            }

            return new JsonResult(dtos);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            bool success = await _dataService.Addresses.DeleteAsync(id);

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(NoContent());
        }
    }
}
