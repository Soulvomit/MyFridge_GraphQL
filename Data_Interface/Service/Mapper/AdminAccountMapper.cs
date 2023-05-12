using Client_Model.Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using System.Linq.Expressions;

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

        public Expression<Func<AdminAccountDto, AdminAccountCto>> ProjectToCto()
        {
            return dto => new AdminAccountCto()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                EmployeeNumber = dto.EmployeeNumber
            };
        }

        public Expression<Func<AdminAccountCto, AdminAccountDto>> ProjectToDto()
        {
            return cto => new AdminAccountDto()
            {
                Id = cto.Id,
                FirstName = cto.FirstName,
                LastName = cto.LastName,
                Password = cto.Password,
                EmployeeNumber = cto.EmployeeNumber
            };
        }
    }
}
