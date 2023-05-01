using Microsoft.EntityFrameworkCore;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Library_Data.DataContext
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<IngredientDto> Ingredients { get; set; }
        public DbSet<RecipeDto> Recipies { get; set; }
        public DbSet<GroceryDto> Groceries { get; set; }
        public DbSet<IngredientAmountDto> IngredientAmounts { get; set; }
        public DbSet<AddressDto> Addresses { get; set; }
        public DbSet<UserAccountDto> Users { get; set; }
        public DbSet<AdminAccountDto> Admins { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccountDto>()
                .HasIndex(ua => ua.Email)
                .IsUnique();
            //modelBuilder.Entity<Ingredient>()
            //    .HasKey(i => new { i.Name, i.Unit });
            //modelBuilder.Entity<Ingredient>().HasData(
            //    new Ingredient { Id = 1, Name = "Carrot", Unit = EUnit.Gram },
            //    new Ingredient { Id = 2, Name = "Ground Beef", Unit = EUnit.Gram },
            //    new Ingredient { Id = 3, Name = "Salt", Unit = EUnit.Gram },
            //    new Ingredient { Id = 4, Name = "Onion", Unit = EUnit.Gram },
            //    new Ingredient { Id = 5, Name = "Chicken Breast", Unit = EUnit.Gram},
            //    new Ingredient { Id = 6, Name = "Heavy Cream", Unit = EUnit.Milliliter },
            //    new Ingredient { Id = 7, Name = "Packet Popcorn", Unit = EUnit.Piece },
            //    new Ingredient { Id = 8, Name = "Butter", Unit = EUnit.Gram },
            //    new Ingredient { Id = 9, Name = "Water", Unit = EUnit.Milliliter },
            //    new Ingredient { Id = 10, Name = "Instant Coffee", Unit = EUnit.Gram },
            //    new Ingredient { Id = 11, Name = "Milk", Unit = EUnit.Milliliter }

            //    //add more ingredients as needed
                //);
  
        }
    }
}