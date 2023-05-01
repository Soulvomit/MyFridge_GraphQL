using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;

namespace Data_Interface.Service.Mapper
{
    public class AdminAccountMapper : IMapperService<AdminAccountDto, AdminAccountCto>
    {
        public AdminAccountCto? ToCto(AdminAccountDto? from)
        {
            if (from == null) return null;

            AdminAccountCto cto = new()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Password = from.Password,
                EmployeeNumber = from.EmployeeNumber
            };

            return cto;
        }
        public AdminAccountDto? ToDto(AdminAccountCto? from)
        {
            if (from == null) return null;

            AdminAccountDto dto = new()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Password = from.Password,
                EmployeeNumber = from.EmployeeNumber
            };

            return dto;
        }
    }
}
