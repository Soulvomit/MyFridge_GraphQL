using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataModel.Enum;

namespace MyFridge_Library_Data.DataContext
{
    public static class ApplicationDbContextSeeder
    {
        private static bool seeded = false;
        public static void Seed(ApplicationDbContext context, bool resetSeeder = false)
        {
            if (resetSeeder) seeded = false;
            if (!seeded)
            {
                IngredientSeed(context);
                GrocerySeed(context);
                OrderSeed(context);
                RecipeSeed(context);
                UserAccountSeed(context);
                context.SaveChanges();
                seeded = true;
            }
        }

        #region IngredientSeed
        public static void IngredientSeed(ApplicationDbContext context)
        {
            context.Ingredients.AddRange(
                new IngredientDto { Id = 1, Name = "Carrot", Unit = EUnit.Gram },
                new IngredientDto { Id = 2, Name = "Ground Beef", Unit = EUnit.Gram },
                new IngredientDto { Id = 3, Name = "Salt", Unit = EUnit.Gram },
                new IngredientDto { Id = 4, Name = "Onion", Unit = EUnit.Gram },
                new IngredientDto { Id = 5, Name = "Chicken Breast", Unit = EUnit.Gram },
                new IngredientDto { Id = 6, Name = "Heavy Cream", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 7, Name = "Packet Popcorn", Unit = EUnit.Piece },
                new IngredientDto { Id = 8, Name = "Butter", Unit = EUnit.Gram },
                new IngredientDto { Id = 9, Name = "Water", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 10, Name = "Instant Coffee", Unit = EUnit.Gram },
                new IngredientDto { Id = 11, Name = "Milk", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 12, Name = "Apple", Unit = EUnit.Piece },
                new IngredientDto { Id = 13, Name = "Banana", Unit = EUnit.Piece },
                new IngredientDto { Id = 14, Name = "Wheat Flour", Unit = EUnit.Gram },
                new IngredientDto { Id = 15, Name = "Kefir", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 16, Name = "Sugar", Unit = EUnit.Gram },
                new IngredientDto { Id = 17, Name = "Brown Sugar", Unit = EUnit.Gram },
                new IngredientDto { Id = 18, Name = "Egg", Unit = EUnit.Piece },
                new IngredientDto { Id = 19, Name = "Baking Powder", Unit = EUnit.Gram },
                new IngredientDto { Id = 20, Name = "Baking Soda", Unit = EUnit.Gram },
                new IngredientDto { Id = 21, Name = "Olive Oil", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 22, Name = "Vegetable Oil", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 23, Name = "Canola Oil", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 24, Name = "Rice", Unit = EUnit.Gram },
                new IngredientDto { Id = 25, Name = "Pasta", Unit = EUnit.Gram },
                new IngredientDto { Id = 26, Name = "Bread", Unit = EUnit.Piece },
                new IngredientDto { Id = 27, Name = "Garlic", Unit = EUnit.Gram },
                new IngredientDto { Id = 28, Name = "Ginger", Unit = EUnit.Gram },
                new IngredientDto { Id = 29, Name = "Black Pepper", Unit = EUnit.Gram },
                new IngredientDto { Id = 30, Name = "Cumin", Unit = EUnit.Gram },
                new IngredientDto { Id = 31, Name = "Paprika", Unit = EUnit.Gram },
                new IngredientDto { Id = 32, Name = "Cayenne Pepper", Unit = EUnit.Gram },
                new IngredientDto { Id = 33, Name = "Chili Powder", Unit = EUnit.Piece },
                new IngredientDto { Id = 34, Name = "Red Pepper Flakes", Unit = EUnit.Gram },
                new IngredientDto { Id = 35, Name = "Oregano", Unit = EUnit.Gram },
                new IngredientDto { Id = 36, Name = "Basil", Unit = EUnit.Gram },
                new IngredientDto { Id = 37, Name = "Parsley", Unit = EUnit.Gram },
                new IngredientDto { Id = 38, Name = "Thyme", Unit = EUnit.Gram },
                new IngredientDto { Id = 39, Name = "Rosemary", Unit = EUnit.Gram },
                new IngredientDto { Id = 40, Name = "Lemon", Unit = EUnit.Piece },
                new IngredientDto { Id = 41, Name = "Lime", Unit = EUnit.Piece },
                new IngredientDto { Id = 42, Name = "Orange", Unit = EUnit.Piece },
                new IngredientDto { Id = 43, Name = "Soy Sauce", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 44, Name = "Worcestershire Sauce", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 45, Name = "Honey", Unit = EUnit.Gram },
                new IngredientDto { Id = 46, Name = "Maple Syrup", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 47, Name = "Tomato", Unit = EUnit.Piece },
                new IngredientDto { Id = 48, Name = "Potato", Unit = EUnit.Piece },
                new IngredientDto { Id = 49, Name = "Sweet Potato", Unit = EUnit.Piece },
                new IngredientDto { Id = 50, Name = "Peas", Unit = EUnit.Gram },
                new IngredientDto { Id = 51, Name = "Corn", Unit = EUnit.Gram },
                new IngredientDto { Id = 52, Name = "Bell Pepper", Unit = EUnit.Piece },
                new IngredientDto { Id = 53, Name = "Broccoli", Unit = EUnit.Gram },
                new IngredientDto { Id = 54, Name = "Cauliflower", Unit = EUnit.Gram },
                new IngredientDto { Id = 55, Name = "Spinach", Unit = EUnit.Gram },
                new IngredientDto { Id = 56, Name = "Kale", Unit = EUnit.Gram },
                new IngredientDto { Id = 57, Name = "Mushroom", Unit = EUnit.Gram },
                new IngredientDto { Id = 58, Name = "Cabbage", Unit = EUnit.Gram },
                new IngredientDto { Id = 59, Name = "Green Beans", Unit = EUnit.Gram },
                new IngredientDto { Id = 60, Name = "Zucchini", Unit = EUnit.Gram },
                new IngredientDto { Id = 61, Name = "Eggplant", Unit = EUnit.Gram },
                new IngredientDto { Id = 62, Name = "Cucumber", Unit = EUnit.Piece },
                new IngredientDto { Id = 63, Name = "Lettuce", Unit = EUnit.Gram },
                new IngredientDto { Id = 64, Name = "Celery", Unit = EUnit.Gram },
                new IngredientDto { Id = 65, Name = "Cheese", Unit = EUnit.Gram },
                new IngredientDto { Id = 66, Name = "Sour Cream", Unit = EUnit.Gram },
                new IngredientDto { Id = 67, Name = "Yogurt", Unit = EUnit.Gram },
                new IngredientDto { Id = 68, Name = "Cottage Cheese", Unit = EUnit.Gram },
                new IngredientDto { Id = 69, Name = "Cream Cheese", Unit = EUnit.Gram },
                new IngredientDto { Id = 70, Name = "Parmesan Cheese", Unit = EUnit.Gram },
                new IngredientDto { Id = 71, Name = "Mozzarella Cheese", Unit = EUnit.Gram },
                new IngredientDto { Id = 72, Name = "Cheddar Cheese", Unit = EUnit.Gram },
                new IngredientDto { Id = 73, Name = "Bacon", Unit = EUnit.Gram },
                new IngredientDto { Id = 74, Name = "Ham", Unit = EUnit.Gram },
                new IngredientDto { Id = 75, Name = "Sausage", Unit = EUnit.Gram },
                new IngredientDto { Id = 76, Name = "Pork", Unit = EUnit.Gram },
                new IngredientDto { Id = 77, Name = "Fish", Unit = EUnit.Gram },
                new IngredientDto { Id = 78, Name = "Shrimp", Unit = EUnit.Gram },
                new IngredientDto { Id = 79, Name = "Crab", Unit = EUnit.Gram },
                new IngredientDto { Id = 80, Name = "Lobster", Unit = EUnit.Gram },
                new IngredientDto { Id = 81, Name = "Tofu", Unit = EUnit.Gram },
                new IngredientDto { Id = 82, Name = "Peanut Butter", Unit = EUnit.Gram },
                new IngredientDto { Id = 83, Name = "Almond Butter", Unit = EUnit.Gram },
                new IngredientDto { Id = 84, Name = "Cashew Butter", Unit = EUnit.Gram },
                new IngredientDto { Id = 85, Name = "Sunflower Seed Butter", Unit = EUnit.Gram },
                new IngredientDto { Id = 86, Name = "Vanilla Extract", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 87, Name = "Almond Extract", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 88, Name = "Nutmeg", Unit = EUnit.Gram },
                new IngredientDto { Id = 89, Name = "Cinnamon", Unit = EUnit.Gram },
                new IngredientDto { Id = 90, Name = "Cocoa Powder", Unit = EUnit.Gram },
                new IngredientDto { Id = 91, Name = "Chocolate Chips", Unit = EUnit.Gram },
                new IngredientDto { Id = 92, Name = "White Chocolate Chips", Unit = EUnit.Gram },
                new IngredientDto { Id = 93, Name = "Raisins", Unit = EUnit.Gram },
                new IngredientDto { Id = 94, Name = "Dried Cranberries", Unit = EUnit.Gram },
                new IngredientDto { Id = 95, Name = "Dried Apricots", Unit = EUnit.Gram },
                new IngredientDto { Id = 96, Name = "Dried Figs", Unit = EUnit.Gram },
                new IngredientDto { Id = 97, Name = "Pecans", Unit = EUnit.Gram },
                new IngredientDto { Id = 98, Name = "Walnuts", Unit = EUnit.Gram },
                new IngredientDto { Id = 99, Name = "Hazelnuts", Unit = EUnit.Gram },
                new IngredientDto { Id = 100, Name = "Almonds", Unit = EUnit.Gram },
                new IngredientDto { Id = 101, Name = "Cashews", Unit = EUnit.Gram },
                new IngredientDto { Id = 102, Name = "Pine Nuts", Unit = EUnit.Gram },
                new IngredientDto { Id = 103, Name = "Peanuts", Unit = EUnit.Gram },
                new IngredientDto { Id = 104, Name = "Sunflower Seeds", Unit = EUnit.Gram },
                new IngredientDto { Id = 105, Name = "Pumpkin Seeds", Unit = EUnit.Gram },
                new IngredientDto { Id = 106, Name = "Flaxseed", Unit = EUnit.Gram },
                new IngredientDto { Id = 107, Name = "Chia Seeds", Unit = EUnit.Gram },
                new IngredientDto { Id = 108, Name = "Sesame Seeds", Unit = EUnit.Gram },
                new IngredientDto { Id = 109, Name = "Quinoa", Unit = EUnit.Gram },
                new IngredientDto { Id = 110, Name = "Couscous", Unit = EUnit.Gram },
                new IngredientDto { Id = 111, Name = "Bulgur", Unit = EUnit.Gram },
                new IngredientDto { Id = 112, Name = "Farro", Unit = EUnit.Gram },
                new IngredientDto { Id = 113, Name = "Barley", Unit = EUnit.Gram },
                new IngredientDto { Id = 114, Name = "Oats", Unit = EUnit.Gram },
                new IngredientDto { Id = 115, Name = "Cornmeal", Unit = EUnit.Gram },
                new IngredientDto { Id = 116, Name = "Canned Tomatoes", Unit = EUnit.Gram },
                new IngredientDto { Id = 117, Name = "Tomato Paste", Unit = EUnit.Gram },
                new IngredientDto { Id = 118, Name = "Paprika", Unit = EUnit.Gram },
                new IngredientDto { Id = 119, Name = "Mayonnaise", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 120, Name = "Ketchup", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 121, Name = "Mustard", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 122, Name = "Croutons", Unit = EUnit.Gram },
                new IngredientDto { Id = 123, Name = "Syrup", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 124, Name = "Maple Syrup", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 125, Name = "Beef Broth", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 126, Name = "Chicken Broth", Unit = EUnit.Milliliter },
                new IngredientDto { Id = 127, Name = "Vegetable Broth", Unit = EUnit.Milliliter }
                );
        }
        #endregion

        #region GrocerySeed
        public static void GrocerySeed(ApplicationDbContext context)
        {
            List<GroceryDto> tempGroceries = new List<GroceryDto>()
            {
                new GroceryDto() { Brand = "VeggiesCo", SalePrice = 12, IngredientAmount = new IngredientAmountDto { Amount = 750, IngredientId = 4 } },
                new GroceryDto() {
                    Brand = "Meat N Greet",
                    SalePrice = 40,
                    IngredientAmount = new IngredientAmountDto
                    {
                        Amount = 500,
                        IngredientId = 5
                    }
                },
                new GroceryDto()
                {
                    Brand = "Arla",
                    SalePrice = 7,
                    IngredientAmount = new IngredientAmountDto
                    {
                        Amount = 1000,
                        IngredientId = 6
                    }
                },
                new GroceryDto() { Brand = "VeggiesCo", SalePrice = 1.50f, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 1 } },
                new GroceryDto() { Brand = "MeatyDelights", SalePrice = 12, IngredientAmount = new IngredientAmountDto { Amount = 750, IngredientId = 2 } },
                new GroceryDto() { Brand = "SaltKing", SalePrice = 0.50f, IngredientAmount = new IngredientAmountDto { Amount = 400, IngredientId = 3 } },
                new GroceryDto() { Brand = "VeggiesCo", SalePrice = 1, IngredientAmount = new IngredientAmountDto { Amount = 300, IngredientId = 4 } },
                new GroceryDto() { Brand = "FarmFresh", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 5 } },
                new GroceryDto() { Brand = "CreamyTreats", SalePrice = 4.50f, IngredientAmount = new IngredientAmountDto { Amount = 950, IngredientId = 6 } },
                new GroceryDto() { Brand = "PopcornPalace", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 5, IngredientId = 7 } },
                new GroceryDto() { Brand = "ButterFarms", SalePrice = 2.50f, IngredientAmount = new IngredientAmountDto { Amount = 400, IngredientId = 8 } },
                new GroceryDto() { Brand = "WholesomeBroths", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 125 } },
                new GroceryDto() { Brand = "WholesomeBroths", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 126 } },
                new GroceryDto() { Brand = "WholesomeBroths", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 127 } },
                new GroceryDto() { Brand = "VeggiesCo", SalePrice = 12, IngredientAmount = new IngredientAmountDto { Amount = 750, IngredientId = 4 } },
                new GroceryDto() { Brand = "CarrotKing", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 1 } },
                new GroceryDto() { Brand = "BeefyGoodness", SalePrice = 40, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 2 } },
                new GroceryDto() { Brand = "SaltShaker", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 3 } },
                new GroceryDto() { Brand = "TastyChick", SalePrice = 22, IngredientAmount = new IngredientAmountDto { Amount = 800, IngredientId = 5 } },
                new GroceryDto() { Brand = "CreamDelight", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 6 } },
                new GroceryDto() { Brand = "PopcornPalooza", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 10, IngredientId = 7 } },
                new GroceryDto() { Brand = "ButterBuddies", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 400, IngredientId = 8 } },
                new GroceryDto() { Brand = "AquaPure", SalePrice = 1, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 9 } },
                new GroceryDto() { Brand = "CaffeineCrush", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 100, IngredientId = 10 } },
                new GroceryDto() { Brand = "MilkMasters", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 2000, IngredientId = 11 } },
                new GroceryDto() { Brand = "AppleAvenue", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 12, IngredientId = 12 } },
                new GroceryDto() { Brand = "BananaBunch", SalePrice = 9, IngredientAmount = new IngredientAmountDto { Amount = 7, IngredientId = 13 } },
                new GroceryDto() { Brand = "FlourFiesta", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 14 } },
                new GroceryDto() { Brand = "KefirKraze", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 750, IngredientId = 15 } },
                new GroceryDto() { Brand = "SweetSensation", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 16 } },
                new GroceryDto() { Brand = "BrownSugarBakery", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 17 } },
                new GroceryDto() { Brand = "Eggcellent", SalePrice = 12, IngredientAmount = new IngredientAmountDto { Amount = 18, IngredientId = 18 } },
                new GroceryDto() { Brand = "BakingBoost", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 19 } },
                new GroceryDto() { Brand = "SodaSupreme", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 230, IngredientId = 20 } },
                new GroceryDto() { Brand = "CheesyChoice", SalePrice = 15, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 21 } },
                new GroceryDto() { Brand = "PastaPerfection", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 22 } },
                new GroceryDto() { Brand = "RiceRendezvous", SalePrice = 11, IngredientAmount = new IngredientAmountDto { Amount = 2000, IngredientId = 23 } },
                new GroceryDto() { Brand = "BreadBounty", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1, IngredientId = 24 } },
                new GroceryDto() { Brand = "OliveOilOasis", SalePrice = 20, IngredientAmount = new IngredientAmountDto { Amount = 750, IngredientId = 25 } },
                new GroceryDto() { Brand = "VinegarVoyage", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 26 } },
                new GroceryDto() { Brand = "HoneyHarvest", SalePrice = 18, IngredientAmount = new IngredientAmountDto { Amount = 450, IngredientId = 27 } },
                new GroceryDto() { Brand = "SpiceSensation", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 50, IngredientId = 28 } },
                new GroceryDto() { Brand = "SoySauceSavvy", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 29 } },
                new GroceryDto() { Brand = "MustardMarvel", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 30 } },
                new GroceryDto() { Brand = "KetchupKingdom", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 31 } },
                new GroceryDto() { Brand = "MayoMagic", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 450, IngredientId = 32 } },
                new GroceryDto() { Brand = "LettuceLand", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 300, IngredientId = 33 } },
                new GroceryDto() { Brand = "TomatoTerritory", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 600, IngredientId = 34 } },
                new GroceryDto() { Brand = "CucumberCorner", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 400, IngredientId = 35 } },
                new GroceryDto() { Brand = "PepperPatch", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 200, IngredientId = 36 } },
                new GroceryDto() { Brand = "OnionOrbit", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 37 } },
                new GroceryDto() { Brand = "GarlicGrove", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 38 } },
                new GroceryDto() { Brand = "LemonLagoon", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 5, IngredientId = 39 } },
                new GroceryDto() { Brand = "OrangeOdyssey", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 10, IngredientId = 40 } },
                new GroceryDto() { Brand = "CheesyChoice", SalePrice = 15, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 21 } },
                new GroceryDto() { Brand = "CheesyChoice", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 200, IngredientId = 41 } },
                new GroceryDto() { Brand = "PastaPerfection", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 22 } },
                new GroceryDto() { Brand = "PastaPerfection", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 42 } },
                new GroceryDto() { Brand = "RiceRendezvous", SalePrice = 11, IngredientAmount = new IngredientAmountDto { Amount = 2000, IngredientId = 23 } },
                new GroceryDto() { Brand = "RiceRendezvous", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 43 } },
                new GroceryDto() { Brand = "BreadBounty", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1, IngredientId = 24 } },
                new GroceryDto() { Brand = "BreadBounty", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 1, IngredientId = 44 } },
                new GroceryDto() { Brand = "OliveOilOasis", SalePrice = 20, IngredientAmount = new IngredientAmountDto { Amount = 750, IngredientId = 25 } },
                new GroceryDto() { Brand = "OliveOilOasis", SalePrice = 12, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 45 } },
                new GroceryDto() { Brand = "VinegarVoyage", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 26 } },
                new GroceryDto() { Brand = "VinegarVoyage", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 46 } },
                new GroceryDto() { Brand = "HoneyHarvest", SalePrice = 18, IngredientAmount = new IngredientAmountDto { Amount = 450, IngredientId = 27 } },
                new GroceryDto() { Brand = "HoneyHarvest", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 47 } },
                new GroceryDto() { Brand = "SpiceSensation", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 50, IngredientId = 28 } },
                new GroceryDto() { Brand = "SpiceSensation", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 25, IngredientId = 48 } },
                new GroceryDto() { Brand = "SoySauceSavvy", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 29 } },
                new GroceryDto() { Brand = "SoySauceSavvy", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 49 } },
                new GroceryDto() { Brand = "MustardMarvel", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 30 } },
                new GroceryDto() { Brand = "MustardMarvel", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 100, IngredientId = 50 } },
                new GroceryDto() { Brand = "KetchupKingdom", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 51 } },
                new GroceryDto() { Brand = "KetchupKingdom", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 52 } },
                new GroceryDto() { Brand = "SugarSupreme", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 2000, IngredientId = 53 } },
                new GroceryDto() { Brand = "SugarSupreme", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 54 } },
                new GroceryDto() { Brand = "SaltSanctuary", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 55 } },
                new GroceryDto() { Brand = "SaltSanctuary", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 56 } },
                new GroceryDto() { Brand = "PepperParadise", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 100, IngredientId = 57 } },
                new GroceryDto() { Brand = "PepperParadise", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 50, IngredientId = 58 } },
                new GroceryDto() { Brand = "MayoMagic", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 59 } },
                new GroceryDto() { Brand = "MayoMagic", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 60 } },
                new GroceryDto() { Brand = "ButterBliss", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 61 } },
                new GroceryDto() { Brand = "ButterBliss", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 62 } },
                new GroceryDto() { Brand = "EggEmporium", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 12, IngredientId = 63 } },
                new GroceryDto() { Brand = "EggEmporium", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 6, IngredientId = 64 } },
                new GroceryDto() { Brand = "MilkMastery", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 65 } },
                new GroceryDto() { Brand = "MilkMastery", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 66 } },
                new GroceryDto() { Brand = "YogurtYard", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 67 } },
                new GroceryDto() { Brand = "YogurtYard", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 68 } },
                new GroceryDto() { Brand = "FlourFinesse", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 2000, IngredientId = 69 } },
                new GroceryDto() { Brand = "FlourFinesse", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 70 } },
                new GroceryDto() { Brand = "BakingSodaBazaar", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 71 } },
                new GroceryDto() { Brand = "BakingSodaBazaar", SalePrice = 1, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 72 } },
                new GroceryDto() { Brand = "BakingPowderPalace", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 73 } },
                new GroceryDto() { Brand = "BakingPowderPalace", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 74 } },
                new GroceryDto() { Brand = "VanillaVilla", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 100, IngredientId = 75 } },
                new GroceryDto() { Brand = "VanillaVilla", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 50, IngredientId = 76 } },
                new GroceryDto() { Brand = "CinnamonCity", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 100, IngredientId = 77 } },
                new GroceryDto() { Brand = "CinnamonCity", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 50, IngredientId = 78 } },
                new GroceryDto() { Brand = "NutmegNook", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 100, IngredientId = 79 } },
                new GroceryDto() { Brand = "NutmegNook", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 50, IngredientId = 80 } },
                new GroceryDto() { Brand = "HoneyHaven", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 81 } },
                new GroceryDto() { Brand = "HoneyHaven", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 82 } },
                new GroceryDto() { Brand = "MapleSyrupSanctum", SalePrice = 12, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 83 } },
                new GroceryDto() { Brand = "MapleSyrupSanctum", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 84 } },
                new GroceryDto() { Brand = "OliveOilOasis", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 85 } },
                new GroceryDto() { Brand = "OliveOilOasis", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 86 } },
                new GroceryDto() { Brand = "VinegarValley", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 87 } },
                new GroceryDto() { Brand = "VinegarValley", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 88 } },
                new GroceryDto() { Brand = "LemonJuiceLagoon", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 89 } },
                new GroceryDto() { Brand = "LemonJuiceLagoon", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 90 } },
                new GroceryDto() { Brand = "LimeJuiceLair", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 91 } },
                new GroceryDto() { Brand = "LimeJuiceLair", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 250, IngredientId = 92 } },
                new GroceryDto() { Brand = "SoySauceShack", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 93 } },
                new GroceryDto() { Brand = "SoySauceShack", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 94 } },
                new GroceryDto() { Brand = "TeriyakiTerrace", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 95 } },
                new GroceryDto() { Brand = "TeriyakiTerrace", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 96 } },
                new GroceryDto() { Brand = "FishSauceFalls", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 97 } },
                new GroceryDto() { Brand = "FishSauceFalls", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 98 } },
                new GroceryDto() { Brand = "WorcestershireWorld", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 99 } },
                new GroceryDto() { Brand = "WorcestershireWorld", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 100 } },
                new GroceryDto() { Brand = "KetchupKingdom", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 101 } },
                new GroceryDto() { Brand = "KetchupKingdom", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 102 } },
                new GroceryDto() { Brand = "MustardMetropolis", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 103 } },
                new GroceryDto() { Brand = "MustardMetropolis", SalePrice = 2, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 104 } },
                new GroceryDto() { Brand = "MayoMeadow", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 105 } },
                new GroceryDto() { Brand = "MayoMeadow", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 106 } },
                new GroceryDto() { Brand = "HotSauceHills", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 107 } },
                new GroceryDto() { Brand = "HotSauceHills", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 108 } },
                new GroceryDto() { Brand = "BBQSauceBeach", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 109 } },
                new GroceryDto() { Brand = "BBQSauceBeach", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 110 } },
                new GroceryDto() { Brand = "PeanutButterParadise", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 111 } },
                new GroceryDto() { Brand = "PeanutButterParadise", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 112 } },
                new GroceryDto() { Brand = "AlmondButterAlley", SalePrice = 10, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 113 } },
                new GroceryDto() { Brand = "AlmondButterAlley", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 114 } },
                new GroceryDto() { Brand = "CashewButterCove", SalePrice = 12, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 115 } },
                new GroceryDto() { Brand = "CashewButterCove", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 116 } },
                new GroceryDto() { Brand = "TahiniTown", SalePrice = 9, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 117 } },
                new GroceryDto() { Brand = "TahiniTown", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 118 } },
                new GroceryDto() { Brand = "JamJunction", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 119 } },
                new GroceryDto() { Brand = "JamJunction", SalePrice = 4, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 120 } },
                new GroceryDto() { Brand = "JellyJubilee", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 121 } },
                new GroceryDto() { Brand = "JellyJubilee", SalePrice = 3, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 122 } },
                new GroceryDto() { Brand = "PreservesPark", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 123 } },
                new GroceryDto() { Brand = "PreservesPark", SalePrice = 5, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 124 } },
                new GroceryDto() { Brand = "MarmaladeMeadows", SalePrice = 8, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 125 } },
                new GroceryDto() { Brand = "MarmaladeMeadows", SalePrice = 6, IngredientAmount = new IngredientAmountDto { Amount = 500, IngredientId = 126 } },
                new GroceryDto() { Brand = "ChocolateChipsCreek", SalePrice = 7, IngredientAmount = new IngredientAmountDto { Amount = 1000, IngredientId = 127 } }
            };
            context.Groceries.AddRange(tempGroceries);
        }
        #endregion

        #region OrderSeed
        private static void OrderSeed(ApplicationDbContext context)
        {
            List<OrderDto> tempOrders = new List<OrderDto>()
            {

            };
            context.Orders.AddRange(tempOrders);
        }
        #endregion

        #region RecipeSeed
        public static void RecipeSeed(ApplicationDbContext context)
        {
            List<RecipeDto> tempRecipes = new List<RecipeDto>()
            {
                new RecipeDto()
                {
                    Name = "Spaghetti Bolognese",
                    Method = """
                        1: Cook ground beef in a pan until browned.
                        2: Add chopped onion and garlic, cook until softened.
                        3: Add canned tomatoes, tomato paste, salt, pepper, and Italian seasoning. 
                        4: Simmer for 20 mins.
                        5: Cook spaghetti according to package instructions.
                        6: Serve spaghetti topped with Bolognese sauce.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 2, Amount = 125 }, // Ground Beef
                        new IngredientAmountDto() { IngredientId = 4, Amount = 25 }, // Onion
                        new IngredientAmountDto() { IngredientId = 25, Amount = 100 }, // Pasta (Spaghetti)
                        new IngredientAmountDto() { IngredientId = 116, Amount = 100 }, // Tomato (canned)
                        new IngredientAmountDto() { IngredientId = 117, Amount = 25 }, // Tomato Paste
                        new IngredientAmountDto() { IngredientId = 3, Amount = 1.25f }, // Salt
                        new IngredientAmountDto() { IngredientId = 29, Amount = 1.25f }, // Black Pepper
                        new IngredientAmountDto() { IngredientId = 21, Amount = 1.25f }, // Olive Oil
                        new IngredientAmountDto() { IngredientId = 36, Amount = 1.25f }, // Basil (part of Italian seasoning)
                        new IngredientAmountDto() { IngredientId = 35, Amount = 1.25f }, // Oregano (part of Italian seasoning)
                        new IngredientAmountDto() { IngredientId = 27, Amount = 6.25f } // Garlic
                    }
                },
                new RecipeDto()
                {
                    Name = "Grilled Chicken Salad",
                    Method = """
                        1: Season chicken breast with salt, pepper, and paprika. Grill until cooked through.
                        2: Chop lettuce, tomato, cucumber, and bell pepper.
                        3: In a large bowl, mix together chopped vegetables.
                        4: Slice grilled chicken and add to the salad.
                        5: Drizzle with your favorite dressing and serve.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 5, Amount = 100 }, // Chicken Breast
                        new IngredientAmountDto() { IngredientId = 3, Amount = 1.25f }, // Salt
                        new IngredientAmountDto() { IngredientId = 29, Amount = 1.25f }, // Black Pepper
                        new IngredientAmountDto() { IngredientId = 118, Amount = 1.25f }, // Paprika
                        new IngredientAmountDto() { IngredientId = 63, Amount = 50 }, // Lettuce
                        new IngredientAmountDto() { IngredientId = 47, Amount = 0.5f }, // Tomato
                        new IngredientAmountDto() { IngredientId = 62, Amount = 0.25f }, // Cucumber
                        new IngredientAmountDto() { IngredientId = 52, Amount = 0.25f } // Bell Pepper
                    }
                },
                new RecipeDto()
                {
                    Name = "Fried Rice",
                    Method = """
                        1: Cook rice according to package instructions and let it cool.
                        2: Heat oil in a pan, add chopped onion and garlic, cook until softened.
                        3: Add chopped vegetables (carrots, peas, corn, and bell pepper) and cook until tender.
                        4: Add cooked rice to the pan and stir to combine.
                        5: Add soy sauce, salt, and pepper to taste. Mix well.
                        6: Create a well in the center of the rice and pour in the beaten eggs. Scramble and mix with rice.
                        7: Serve hot.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 24, Amount = 75 },
                        new IngredientAmountDto() { IngredientId = 22, Amount = 10 },
                        new IngredientAmountDto() { IngredientId = 4, Amount = 25 },
                        new IngredientAmountDto() { IngredientId = 27, Amount = 4 },
                        new IngredientAmountDto() { IngredientId = 1, Amount = 25 },
                        new IngredientAmountDto() { IngredientId = 51, Amount = 25 },
                        new IngredientAmountDto() { IngredientId = 50, Amount = 25 },
                        new IngredientAmountDto() { IngredientId = 52, Amount = 0.25f },
                        new IngredientAmountDto() { IngredientId = 43, Amount = 10 },
                        new IngredientAmountDto() { IngredientId = 3, Amount = 1.25f },
                        new IngredientAmountDto() { IngredientId = 29, Amount = 0.5f },
                        new IngredientAmountDto() { IngredientId = 18, Amount = 0.5f }
                    }
                },
                new RecipeDto()
                {
                    Name = "Cheese Omelette",
                    Method = """
                        1: In a bowl, beat the eggs with salt and pepper.
                        2: Heat oil in a pan, pour in the egg mixture.
                        3: When the eggs are almost set, sprinkle grated cheese on one side.
                        4: Fold the omelette in half and cook until the cheese is melted.
                        5: Serve hot.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 18, Amount = 2 }, // Eggs
                        new IngredientAmountDto() { IngredientId = 3, Amount = 2 }, // Salt
                        new IngredientAmountDto() { IngredientId = 29, Amount = 2 }, // Pepper
                        new IngredientAmountDto() { IngredientId = 21, Amount = 10 }, // Olive oil
                        new IngredientAmountDto() { IngredientId = 72, Amount = 30 } // Grated Cheese
                    }
                },
                new RecipeDto()
                {
                    Name = "Caesar Salad",
                    Method = """
                        1: Chop Romaine lettuce and set aside.
                        2: In a bowl, mix together mayonnaise, lemon juice, garlic, Worcestershire sauce, Dijon mustard, and grated Parmesan cheese.
                        3: In a large bowl, toss the lettuce with the dressing.
                        4: Top with croutons and extra grated Parmesan cheese.
                        5: Serve immediately.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 63, Amount = 67 }, // Romaine lettuce
                        new IngredientAmountDto() { IngredientId = 119, Amount = 33 }, // Mayonnaise
                        new IngredientAmountDto() { IngredientId = 40, Amount = 0.25f }, // Lemon juice
                        new IngredientAmountDto() { IngredientId = 24, Amount = 2 },  // Garlic
                        new IngredientAmountDto() { IngredientId = 38, Amount = 2 },  // Worcestershire sauce
                        new IngredientAmountDto() { IngredientId = 121, Amount = 3 },  // Dijon mustard
                        new IngredientAmountDto() { IngredientId = 70, Amount = 17 }, // Grated Parmesan cheese
                        new IngredientAmountDto() { IngredientId = 122, Amount = 17 }  // Croutons
                    }
                },
                new RecipeDto()
                {
                    Name = "Grilled Cheese Sandwich",
                    Method = """
                        1: Butter one side of each slice of bread.
                        2: Place a slice of cheddar cheese between the buttered sides of the bread slices.
                        3: Heat a non-stick pan over medium heat.
                        4: Place the sandwich in the pan and cook until golden brown on each side and cheese is melted.
                        5: Serve hot.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 26, Amount = 2 }, // Slice of bread
                        new IngredientAmountDto() { IngredientId = 8, Amount = 10 },  // Butter
                        new IngredientAmountDto() { IngredientId = 72, Amount = 40 } // Cheddar cheese
                    }
                },
                new RecipeDto()
                {
                    Name = "Chicken and Vegetable Stir Fry",
                    Method = """
                        1: Cut the chicken breast into small pieces.
                        2: Chop the carrots, bell pepper, onion, and broccoli.
                        3: Heat vegetable oil in a wok or large frying pan over medium heat.
                        4: Add the chopped vegetables and cook for 5 minutes, stirring frequently.
                        5: Add the chicken pieces and cook until the chicken is cooked through.
                        6: Add soy sauce and cook for an additional 2 minutes, stirring to combine.
                        7: Serve over cooked rice.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 5, Amount = 150 }, // Chicken Breast
                        new IngredientAmountDto() { IngredientId = 1, Amount = 100 }, // Carrot
                        new IngredientAmountDto() { IngredientId = 52, Amount = 1 },  // Bell Pepper
                        new IngredientAmountDto() { IngredientId = 4, Amount = 100 }, // Onion
                        new IngredientAmountDto() { IngredientId = 53, Amount = 100 }, // Broccoli
                        new IngredientAmountDto() { IngredientId = 22, Amount = 15 },  // Vegetable Oil
                        new IngredientAmountDto() { IngredientId = 43, Amount = 30 },  // Soy Sauce
                        new IngredientAmountDto() { IngredientId = 24, Amount = 150 }  // Rice
                    }
                },
                new RecipeDto()
                {
                    Name = "Creamy Tomato Pasta",
                    Method = """
                        1: Cook pasta according to package instructions.
                        2: In a large saucepan, heat olive oil over medium heat.
                        3: Add chopped garlic and cook for 1 minute.
                        4: Add canned tomatoes, salt, and black pepper. Simmer for 10 minutes.
                        5: Stir in heavy cream and cook for another 5 minutes.
                        6: Drain the cooked pasta and add it to the sauce, stirring to combine.
                        7: Serve hot, garnished with grated parmesan cheese.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 25, Amount = 100 }, // Pasta
                        new IngredientAmountDto() { IngredientId = 21, Amount = 15 },  // Olive Oil
                        new IngredientAmountDto() { IngredientId = 27, Amount = 10 },  // Garlic
                        new IngredientAmountDto() { IngredientId = 116, Amount = 400 }, // Canned Tomatoes
                        new IngredientAmountDto() { IngredientId = 3, Amount = 2 },  // Salt
                        new IngredientAmountDto() { IngredientId = 29, Amount = 1 },  // Black Pepper
                        new IngredientAmountDto() { IngredientId = 6, Amount = 120 },  // Heavy Cream
                        new IngredientAmountDto() { IngredientId = 70, Amount = 20 }  // Parmesan Cheese
                    }
                },
                new RecipeDto()
                {
                    Name = "Pancakes",
                    Method = """
                        1: In a bowl, whisk together flour, baking powder, salt, sugar, milk, egg, and melted butter.
                        2: Heat a non-stick pan over medium heat.
                        3: Pour a small amount of batter into the pan, cook until bubbles appear on the surface, then flip and cook until golden brown.
                        4: Repeat with the remaining batter.
                        5: Serve pancakes with maple syrup or your favorite toppings.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 14, Amount = 50 }, // Flour
                        new IngredientAmountDto() { IngredientId = 19, Amount = 1 }, // Baking powder
                        new IngredientAmountDto() { IngredientId = 3, Amount = 1.25f }, // Salt
                        new IngredientAmountDto() { IngredientId = 16, Amount = 5 }, // Sugar
                        new IngredientAmountDto() { IngredientId = 11, Amount = 62.5f }, // Milk
                        new IngredientAmountDto() { IngredientId = 18, Amount = 0.25f }, // Eggs
                        new IngredientAmountDto() { IngredientId = 8, Amount = 12.5f }, // Butter
                        new IngredientAmountDto() { IngredientId = 124, Amount = 50 }, // Maple syrup or other toppings
                    }
                },
                new RecipeDto()
                {
                    Name = "Tomato Soup",
                    Method = """
                        1: In a pot, heat oil and cook chopped onion and garlic until softened.
                        2: Add canned tomatoes, vegetable broth, salt, and pepper. 
                        3: Simmer for 20 minutes.
                        4: Use an immersion blender to blend the soup until smooth.
                        5: Stir in heavy cream and heat through.
                        6: Serve hot with crusty bread.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 4, Amount = 12.5f },
                        new IngredientAmountDto() { IngredientId = 27, Amount = 2.5f },
                        new IngredientAmountDto() { IngredientId = 116, Amount = 200 },
                        new IngredientAmountDto() { IngredientId = 127, Amount = 125 },
                        new IngredientAmountDto() { IngredientId = 3, Amount = 1.25f },
                        new IngredientAmountDto() { IngredientId = 29, Amount = 1.25f },
                        new IngredientAmountDto() { IngredientId = 6, Amount = 25 },
                        new IngredientAmountDto() { IngredientId = 26, Amount = 1 }
                    }
                },
                new RecipeDto()
                {
                    Name = "Chicken Alfredo",
                    Method = """
                        1: Season chicken breast with salt and pepper, cook on a pan until done. Set aside.
                        2: Cook fettuccine according to package instructions.
                        3: In a pan, melt butter and add garlic, cook for 1 minute. Add heavy cream and bring to a simmer.
                        4: Stir in grated Parmesan cheese and cook until the sauce thickens.
                        5: Slice cooked chicken and add to the sauce. Mix in the cooked fettuccine.
                        6: Serve hot.
                        """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 5, Amount = 100 },
                        new IngredientAmountDto() { IngredientId = 3, Amount = 1.25f },
                        new IngredientAmountDto() { IngredientId = 21, Amount = 1.25f },
                        new IngredientAmountDto() { IngredientId = 80, Amount = 75 },
                        new IngredientAmountDto() { IngredientId = 8, Amount = 12.5f },
                        new IngredientAmountDto() { IngredientId = 24, Amount = 2.5f },
                        new IngredientAmountDto() { IngredientId = 6, Amount = 62.5f },
                        new IngredientAmountDto() { IngredientId = 70, Amount = 25 }
                    }
                },
                new RecipeDto()
                {
                    Name = "Chicken and Vegetable Pie",
                    Method = """
                            1: Preheat your oven to 200°C (390°F).
                            2: Dice the carrot and onion. Cut the chicken breast into bite-sized pieces.
                            3: In a skillet, melt 5g of butter over medium heat. Add the diced onion and carrot, and cook for 5 minutes until softened.
                            4: Add the chicken breast to the skillet and cook until it's no longer pink on the outside, about 3 minutes.
                            5: Stir in the thyme, rosemary, salt, and black pepper. Add the chicken broth and cook for another 3 minutes until slightly reduced.
                            6: In a separate bowl, mix together the wheat flour, 5g of melted butter, and milk to form a dough.
                            7: On a floured surface, roll out the dough to fit your individual pie dish. Place the dough in the pie dish, pressing it against the sides and bottom.
                            8: Pour the chicken and vegetable mixture into the pie crust.
                            9: Roll out the remaining dough and place it on top of the pie, sealing the edges with a fork or your fingers. Cut a few slits in the top crust to allow steam to escape.
                            10: Bake the pie in the preheated oven for 25-30 minutes, or until the crust is golden brown. Remove from the oven and let it cool for a few minutes before serving. Enjoy your savory vegetable and chicken pie!
                            """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 5, Amount = 100 }, // Chicken Breast
                        new IngredientAmountDto() { IngredientId = 50, Amount = 50 }, // Peas
                        new IngredientAmountDto() { IngredientId = 53, Amount = 50 }, // Broccoli
                        new IngredientAmountDto() { IngredientId = 4, Amount = 25 }, // Onion
                        new IngredientAmountDto() { IngredientId = 27, Amount = 5 }, // Garlic
                        new IngredientAmountDto() { IngredientId = 65, Amount = 20 }, // Cheese
                        new IngredientAmountDto() { IngredientId = 6, Amount = 60 }, // Heavy Cream
                        new IngredientAmountDto() { IngredientId = 8, Amount = 15 }, // Butter
                        new IngredientAmountDto() { IngredientId = 14, Amount = 60 }, // Wheat Flour
                        new IngredientAmountDto() { IngredientId = 3, Amount = 1 }, // Salt
                        new IngredientAmountDto() { IngredientId = 29, Amount = 1 } // Black Pepper
                    }
                },
                new RecipeDto()
                {
                    Name = "Beef Lasagna",
                    Method = """
                            1: Preheat your oven to 190°C (375°F).
                            2: Cook the lasagna noodles according to the package instructions until al dente. 
                            3: Drain and set aside.
                            4: In a skillet, heat the olive oil over medium heat. 
                            5: Add the ground beef, salt, and black pepper. 
                            6: Cook until the beef is browned, breaking it up into smaller pieces as it cooks. 
                            7: Remove the skillet from heat and drain any excess fat.
                            8: Stir the canned tomato into the cooked ground beef. 
                            9: Add the oregano and basil, mixing well.
                            10: In an individual-sized baking dish, spread a small layer of the beef and marinara mixture at the bottom. 
                            11: Place a lasagna noodle over it, followed by a layer of ricotta cheese.
                            12: Repeat the layering process with the beef mixture, lasagna noodles, and ricotta cheese until you have used all the noodles. 
                            13: The top layer should be the beef mixture.
                            14: Sprinkle the shredded mozzarella and grated Parmesan cheese over the top layer.
                            15: Cover the baking dish with aluminum foil, ensuring it doesn't touch the cheese.
                            16: Bake in the preheated oven for 25 minutes. 
                            17: Then, remove the foil and bake for another 10-15 minutes, or until the cheese is melted and bubbly.
                            18: Let the lasagna cool for a few minutes before serving. 
                            19: Enjoy your beef lasagna!
                            """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto { IngredientId = 2, Amount = 200 },
                        new IngredientAmountDto { IngredientId = 3, Amount = 3 },
                        new IngredientAmountDto { IngredientId = 21, Amount = 21 },
                        new IngredientAmountDto { IngredientId = 29, Amount = 1 },
                        new IngredientAmountDto { IngredientId = 35, Amount = 2 },
                        new IngredientAmountDto { IngredientId = 36, Amount = 2 },
                        new IngredientAmountDto { IngredientId = 70, Amount = 25 },
                        new IngredientAmountDto { IngredientId = 71, Amount = 50 },
                        new IngredientAmountDto { IngredientId = 116, Amount = 200 }
                    }
                },
                new RecipeDto() 
                { 
                    Name = "Buttered Popcorn", 
                    Method = """
                            1: Cook popcorn in microwave for 3 mins. 
                            2: Add butter to popcorn and wait until melted. 
                            3: Done.
                            """, 
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 7, Amount = 1 },
                        new IngredientAmountDto() { IngredientId = 8, Amount = 100 }
                    },
                },
                new RecipeDto() 
                { 
                    Name = "Cafe Latte", 
                    Method = """
                            1: Boil Water. 
                            2: Add instant coffee. 
                            3: Whip milk and to coffee. 
                            4: Done.
                            """,
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto() { IngredientId = 9, Amount = 50 },
                        new IngredientAmountDto() { IngredientId = 10, Amount = 10 },
                        new IngredientAmountDto() { IngredientId = 11, Amount = 70 }
                    }
                }
            };
            context.Recipies.AddRange(tempRecipes);
        }
        #endregion

        #region UserAccountSeed
        public static void UserAccountSeed(ApplicationDbContext context)
        {
            List<UserAccountDto> tempUsers = new List<UserAccountDto>()
            {
                new UserAccountDto
                {
                    FirstName = "Jonas",
                    LastName = "Brown",
                    Password = "password",
                    Address = new AddressDto()
                    {
                        Id = 1,
                        Street = "Cambridge Street 231",
                        Extension = null,
                        City = "New York",
                        State = "New York",
                        ZipCode = "12345-12345",
                        Country = ECountry.UnitedStates
                    },
                    Email = "email@email.com",
                    PhoneNumber = 4540302010,
                    BirthDate = new DateTime(1983, 02, 09, 00, 00, 00),
                    IngredientAmounts = new List<IngredientAmountDto>()
                    {
                        new IngredientAmountDto()
                        {
                            IngredientId = 12,
                            Amount = 10
                        },
                        new IngredientAmountDto()
                        {
                            IngredientId = 13,
                            Amount = 3
                        },
                        new IngredientAmountDto()
                        {
                            IngredientId = 14,
                            Amount = 1000
                        },
                        new IngredientAmountDto()
                        {
                            IngredientId = 15,
                            Amount = 1000
                        }
                    }
                },
                new UserAccountDto
                {
                    FirstName = "Bertram Vandsted",
                    LastName = "Brown",
                    Password = "password1",
                    Address = new AddressDto()
                    {
                        Id = 2,
                        Street = "Skellet 1",
                        Extension = "2. MF.",
                        City = "Glostup",
                        State = "Copenhagen",
                        ZipCode = "2600",
                        Country = ECountry.Denmark
                    },
                    Email = "email1@email.com",
                    PhoneNumber = 4540302010,
                    BirthDate = new DateTime(2022, 01, 29, 00, 00, 00)
                },
                new UserAccountDto
                {
                    FirstName = "Ada-Noelle Kirsten Vandsted",
                    LastName = "Brown",
                    Password = "password2",
                    Address = new AddressDto()
                    {
                        Id = 3,
                        Street = "Holmvej 259",
                        Extension = "1. MF.",
                        City = "Hoejbjerg",
                        State = "Aarhus",
                        ZipCode = "8270",
                        Country = ECountry.Denmark
                    },
                    Email = "email2@email.com",
                    PhoneNumber = 4540302010,
                    BirthDate = new DateTime(2022, 01, 29, 00, 00, 00)
                }
            };
            context.Users.AddRange(tempUsers);
        }
        #endregion
    }
}
