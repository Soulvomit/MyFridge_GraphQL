using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class GroceryMutation : MutationQL
    {
        public GroceryMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<GroceryCto?> CreateGroceryAsync(ApplicationDbContext context, GroceryCto cto)
        {
            if (cto == null) return null;

            cto.Id = default;
            GroceryDto? dto = _map.Grocery.ToDto(from: cto);

            if (dto == null) return null;

            await context.Groceries.AddAsync(dto);

            await context.SaveChangesAsync();
            return _map.Grocery.ToCto(from: dto);
        }
        public async Task<GroceryCto?> UpdateGroceryAsync(ApplicationDbContext context, GroceryCto cto)
        {
            if (cto == null) return null;

            GroceryDto? dto = _map.Grocery.ToDto(from: cto);

            if (dto == null) return null;

            context.Groceries.Update(dto);

            await context.SaveChangesAsync();
            return _map.Grocery.ToCto(from: dto);
        }
        public async Task<GroceryCto?> ChangeGroceryAsync(ApplicationDbContext context, GroceryCto cto)
        {
            if (cto == null) return null;

            GroceryDto? dto = await context.Groceries.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.Brand = cto.Brand;
            dto.SalePrice = cto.SalePrice;
            dto.ItemIdentifier = cto.ItemIdentifier;
            dto.ImageUrl = cto.ImageUrl;

            if (dto.IngredientAmount != null) 
            {
                context.IngredientAmounts.Remove(dto.IngredientAmount);
                dto.IngredientAmount = null;
            }

            dto.IngredientAmount = _map.IngredientAmount.ToDto(cto.IngredientAmount);

            await context.SaveChangesAsync();
            return _map.Grocery.ToCto(dto);
        }
        public async Task<bool> DeleteGroceryAsync(ApplicationDbContext context, GroceryCto cto)
        {
            if (cto == null) return false;

            GroceryDto? dto = await context.Groceries.FindAsync(cto.Id);

            if (dto == null) return false;

            context.Groceries.Remove(dto);

            await context.SaveChangesAsync();
            return true;
        }
        public async Task<GroceryCto?> ChangeGroceryCoreAsync(ApplicationDbContext context, GroceryCto cto)
        {
            if (cto == null) return null;

            GroceryDto? dto = await context.Groceries.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.Brand = cto.Brand;
            dto.SalePrice = cto.SalePrice;
            dto.ItemIdentifier = cto.ItemIdentifier;
            dto.ImageUrl = cto.ImageUrl;

            await context.SaveChangesAsync();
            return _map.Grocery.ToCto(dto);
        }
        public async Task<GroceryCto?> ChangeGroceryIngredientAmountAsync(
            ApplicationDbContext context, 
            GroceryCto cto, 
            IngredientAmountCto ingredientAmountCto)
        {
            if (cto == null) return null;

            GroceryDto? dto = await context.Groceries.FindAsync(cto.Id);

            if (dto == null) return null;

            IngredientAmountDto? ingredientAmountDto = await context.IngredientAmounts.FindAsync(ingredientAmountCto.Id);

            if (ingredientAmountDto == null)
            {
                dto.IngredientAmount = _map.IngredientAmount.ToDto(ingredientAmountCto);
            }
            else
            {
                if (dto.IngredientAmount != null)
                {
                    context.IngredientAmounts.Remove(dto.IngredientAmount);
                    dto.IngredientAmount = null;
                }

                dto.IngredientAmount = ingredientAmountDto;
            }

            await context.SaveChangesAsync();
            return _map.Grocery.ToCto(dto);
        }
    }
}
