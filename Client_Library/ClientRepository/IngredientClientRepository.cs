﻿using Client_Library.Abstract;
using Client_Library.Interface;
using Client_Model;

namespace Client_Library.ClientRepository
{
    public class IngredientClientRepository : ClientRepository<IngredientCto>, IIngredientClientRepository
    {
        public IngredientClientRepository(string baseAddress) : base(baseAddress) { }
    }
}