﻿namespace MyFridge_Library_MAUI_DataTransfer.DataTransferObject
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public float Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}