﻿using Client_Model.Interface;
using HotChocolate;

namespace Client_Model
{
    public class IngredientAmountCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public IngredientCto Ingredient { get; set; }
        [GraphQLType(typeof(float?))]
        public float Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}