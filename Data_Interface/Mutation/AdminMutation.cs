using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class AdminMutation : MutationQL
    {
        public AdminMutation(
                    IDbContextFactory<ApplicationDbContext> dbContextFactory,
                    IMapperUoW map,
                    ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<AdminAccountCto?> CreateAdminAsync(ApplicationDbContext context, AdminAccountCto cto)
        {
            if (cto == null) return null;

            cto.Id = default;
            AdminAccountDto? dto = _map.Admin.ToDto(from: cto);

            if (dto == null) return null;

            await context.Admins.AddAsync(dto);

            await context.SaveChangesAsync();
            return _map.Admin.ToCto(from: dto);
        }
        public async Task<AdminAccountCto?> UpdateAdminAsync(ApplicationDbContext context, AdminAccountCto cto)
        {
            if (cto == null) return null;

            AdminAccountDto? dto = _map.Admin.ToDto(from: cto);

            if (dto == null) return null;

            context.Admins.Update(dto);

            await context.SaveChangesAsync();
            return _map.Admin.ToCto(from: dto);
        }
        public async Task<bool> DeleteAdminAsync(ApplicationDbContext context, AdminAccountCto cto)
        {
            if (cto == null) return false;

            AdminAccountDto? dto = await context.Admins.FindAsync(cto.Id);

            if (dto == null) return false;

            context.Admins.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<AdminAccountCto?> ChangeAdminCoreAsync(ApplicationDbContext context, AdminAccountCto cto)
        {
            if (cto == null) return null;

            AdminAccountDto? dto = await context.Admins.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.FirstName = cto.FirstName;
            dto.LastName = cto.LastName;
            dto.Password = cto.Password;
            dto.EmployeeNumber = cto.EmployeeNumber;

            await context.SaveChangesAsync();
            return _map.Admin.ToCto(dto);
        }
    }
}
