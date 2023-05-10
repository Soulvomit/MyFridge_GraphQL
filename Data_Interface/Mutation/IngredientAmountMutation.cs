using Client_Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class IngredientAmountMutation : MutationQL
    {
        public IngredientAmountMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<IngredientAmountCto?> CreateIngredientAmountAsync(ApplicationDbContext context, IngredientAmountCto cto)
        {
            cto.Id = 0;
            IngredientAmountDto? dto = _map.IngredientAmount.ToDto(from: cto);

            await context.IngredientAmounts.AddAsync(dto);
            await context.SaveChangesAsync();
            return _map.IngredientAmount.ToCto(from: dto);
        }
        public async Task<IngredientAmountCto?> UpdateIngredientAmountAsync(ApplicationDbContext context, IngredientAmountCto cto)
        {
            IngredientAmountDto? dto = _map.IngredientAmount.ToDto(from: cto);

            context.IngredientAmounts.Update(dto);
            await context.SaveChangesAsync();
            return _map.IngredientAmount.ToCto(from: dto);
        }
        public async Task<bool> DeleteIngredientAmountAsync(ApplicationDbContext context, IngredientAmountCto cto)
        {
            IngredientAmountDto? dto = await context.IngredientAmounts.FindAsync(cto.Id);

            if (dto == null)
                return false;

            context.IngredientAmounts.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
