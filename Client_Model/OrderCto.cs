﻿using Client_Model.Interface;
using HotChocolate;

namespace Client_Model
{
    public class OrderCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        [GraphQLType(typeof(DateTime?))]
        public DateTime Created { get; set; }
        [GraphQLType(typeof(int?))]
        public int Status { get; set; }
        public List<GroceryCto> Groceries { get; set; } = new List<GroceryCto>();
        [GraphQLIgnore]
        public float TotalPriceDkk
        {
            get
            {
                float total = 0;

                foreach (var item in Groceries)
                    total += item.SalePrice;

                return total;
            }
        }
    }
}