using Microsoft.AspNetCore.Mvc;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;
using MyFridge_Interface_WebAPI.Service.Data.Interface;

namespace MyFridge_Interface_WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapperService _map;
        private readonly ILogger<UserAccountController> _log;

        public UserAccountController(IDataService dataService, IMapperService map, ILogger<UserAccountController> log)
        {
            _dataService = dataService;
            _map = map;
            _log = log;
        }
        //create/edit
        [HttpPost]
        public async Task<JsonResult> UpsertAsync([FromBody] UserAccountCto dto)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            if (dto.Id == 0) await _dataService.Users.CreateAsync(_map.ToUserAccountDto(from: dto));
            else
            {            
                bool success = await _dataService.Users.UpdateAsync(_map.ToUserAccountDto(from: dto));

                if (!success) return new JsonResult(NotFound());
            }

            await _dataService.CompleteAsync();

            return new JsonResult(dto);
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync(int id)
        {
            UserAccountDto? user = await _dataService.Users.GetAsync(id);

            if (user == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToUserAccountCto(from: user));
        }
        [HttpGet]
        public async Task<JsonResult> GetByEmailAsync(string email)
        {
            UserAccountDto? user = await _dataService.Users.GetByEmailAsync(email);

            if (user == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToUserAccountCto(from: user));
        }
        [HttpGet]
        public async Task<JsonResult> GetOrdersAsync(int id)
        {
            UserAccountDto? user = await _dataService.Users.GetAsync(id);

            if (user == null) return new JsonResult(NotFound());

            return new JsonResult(_map.ToUserAccountCto(from: user).Orders);
        }
        [HttpGet]
        public async Task<JsonResult> GetFilteredAsync(string filter, int minLength = 2)
        {
            Func<UserAccountDto, bool> filterFunc = user =>
            {
                bool firstNameMatches = user.FirstName.ToLower().Contains(filter.ToLower());
                bool lastNameMatches = user.LastName.ToLower().Contains(filter.ToLower());

                return firstNameMatches || lastNameMatches;
            };

            Func<UserAccountDto, object> orderByFunc = user => user.LastName + " " + user.FirstName;

            List<UserAccountCto> dtos = new();
            List<UserAccountDto>? filteredUsers = await _dataService.Users.Query(filterFunc, orderByFunc, filter, minLength);

            if (filteredUsers == null) return new JsonResult(NotFound());

            foreach (UserAccountDto user in filteredUsers)
            {
                dtos.Add(_map.ToUserAccountCto(from: user));
            }
            return new JsonResult(dtos);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllAsync()
        {
            List<UserAccountCto> dtos = new List<UserAccountCto>();
            List<UserAccountDto> users = await _dataService.Users.GetAllAsync();

            foreach (UserAccountDto user in users)
            {
                dtos.Add(_map.ToUserAccountCto(from: user));
            }

            return new JsonResult(dtos);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            bool success = await _dataService.Users.DeleteAsync(id);

            if (!success) return new JsonResult(NotFound());

            await _dataService.CompleteAsync();

            return new JsonResult(NoContent());
        }
    }
}