﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyFridge_Library_Data.Data.Repository.Base;
using MyFridge_Library_Data.Data.Repository.Interface;
using MyFridge_Library_Data.Model;

namespace MyFridge_Library_Data.Data.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        public override async Task<bool> UpdateAsync(Recipe updateEntity)
        {
            if (updateEntity == null) return false;

            Recipe? entityInDb = await dbSet.FindAsync(updateEntity.Id);

            if (entityInDb == null) return false;

            entityInDb.Name = updateEntity.Name;
            entityInDb.Method = updateEntity.Method;
            entityInDb.ImageUrl = updateEntity.ImageUrl;

            return true;
        }

        #region Ingredients
        public async Task<bool> AddIngredientAmountAsync(int id, IngredientAmount addEntity)
        {
            Recipe? entityInDb = await GetAsync(id);

            if (entityInDb == null) return false;

            entityInDb.IngredientAmounts.Add(addEntity);
            return true;
        }
        public async Task<bool> BatchIngredientAmountAsync(int id, IngredientAmount addEntity)
        {
            Recipe? entityInDb = await GetAsync(id);

            if (entityInDb == null) return false;

            IngredientAmount? foundEntity = entityInDb.IngredientAmounts.
                FirstOrDefault(ia => ia.Ingredient.Id == addEntity.Ingredient.Id);

            if (foundEntity != null)
                foundEntity.Amount += addEntity.Amount;
            else
                entityInDb.IngredientAmounts.Add(addEntity);

            return true;
        }
        public async Task<bool> RemoveAmountAsync(int id, int ingredientAmountId, float removeAmount, bool forceRemove = true)
        {
            Recipe? entityInDb = await GetAsync(id);

            if (entityInDb == null) return false;

            IngredientAmount? foundEntity = entityInDb.IngredientAmounts
                .FirstOrDefault(ia => ia.Id == ingredientAmountId);

            if (foundEntity == null) return false;

            if (foundEntity.Amount >= removeAmount)
            {
                foundEntity.Amount -= removeAmount;

                if (foundEntity.Amount == 0)
                {
                    entityInDb.IngredientAmounts.Remove(foundEntity);
                    _context.IngredientAmounts.Remove(foundEntity);
                }
                return true;
            }
            if (foundEntity.Amount < removeAmount && forceRemove)
            {
                entityInDb.IngredientAmounts.Remove(foundEntity);
                _context.IngredientAmounts.Remove(foundEntity);

                return true;
            }
            return false;
        }
        public async Task<bool> RemoveIngredientAmountAsync(int id, IngredientAmount removeEntity)
        {
            Recipe? entityInDb = await GetAsync(id);

            if (entityInDb == null) return false;

            entityInDb.IngredientAmounts.Remove(removeEntity);
            _context.IngredientAmounts.Remove(removeEntity);

            return true;
        }
        public async Task<bool> RemoveIngredientAmountAsync(int id, int ingredientAmountId)
        {
            Recipe? entityInDb = await GetAsync(id);
            if (entityInDb == null) return false;

            IngredientAmount? iaEntityInDb = await _context.IngredientAmounts.FindAsync(ingredientAmountId);
            if (iaEntityInDb == null) return false;

            entityInDb.IngredientAmounts.Remove(iaEntityInDb);
            _context.IngredientAmounts.Remove(iaEntityInDb);

            return true;
        }
        //public async Task<bool> AddIngredientAsync(int id, Ingredient addEntity, float addAmount)
        //{
        //    Task<Recipe?> t1 = GetAsync(id);
        //    Task<Ingredient?> t2 = _context.Ingredients
        //        .Where(ingredient => ingredient.Id == addEntity.Id)
        //        .FirstOrDefaultAsync();

        //    await Task.WhenAll(t1, t2);

        //    Recipe? recipeEntityInDb = t1.Result;
        //    Ingredient? ingredientEntityInDb = t2.Result;

        //    if (recipeEntityInDb == null) return false;

        //    if (ingredientEntityInDb == null)
        //    {
        //        recipeEntityInDb.IngredientAmounts.Add(
        //            new IngredientAmount
        //            {
        //                Ingredient = addEntity,
        //                Amount = addAmount
        //            });
        //    }
        //    else
        //    {
        //        recipeEntityInDb.IngredientAmounts.Add(
        //            new IngredientAmount
        //            {
        //                Ingredient = ingredientEntityInDb,
        //                Amount = addAmount
        //            });
        //    }

        //    return true;
        //}
        //public async Task<bool> AddIngredientAsync(int id, IngredientAmount addEntity)
        //{
        //    Task<Recipe?> t1 = GetAsync(id);
        //    Task<IngredientAmount?> t2 = _context.IngredientAmounts
        //        .Where(ingredient => ingredient.Id == addEntity.Id)
        //        .FirstOrDefaultAsync();

        //    await Task.WhenAll(t1, t2);

        //    Recipe? recipeEntityInDb = t1.Result;
        //    IngredientAmount? ingredientAmountEntityInDb = t2.Result;

        //    if (recipeEntityInDb == null) return false;

        //    if (ingredientAmountEntityInDb == null)
        //        recipeEntityInDb.IngredientAmounts.Add(addEntity);
        //    else
        //        recipeEntityInDb.IngredientAmounts.Add(ingredientAmountEntityInDb);

        //    return true;
        //}
        #endregion
    }
}
