using Microsoft.Extensions.Logging;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataRepository.Abstract;
using MyFridge_Library_Data.DataRepository.Interface;

namespace MyFridge_Library_Data.DataRepository
{
    public class AddressDataRepository : DataRepository<AddressDto>, IAddressDataRepository
    {
        public AddressDataRepository(ApplicationDbContext context, ILogger log)
            : base(context, log)
        {
        }

        public override async Task<bool> UpdateAsync(AddressDto updateEntity)
        {
            if (updateEntity == null) return false;

            AddressDto? entityInDb = await dbSet.FindAsync(updateEntity.Id);

            if (entityInDb == null) return false;

            entityInDb.Street = updateEntity.Street;
            entityInDb.Extension = updateEntity.Extension;
            entityInDb.City = updateEntity.City;
            entityInDb.State = updateEntity.State;
            entityInDb.ZipCode = updateEntity.ZipCode;
            entityInDb.Country = updateEntity.Country;

            return true;
        }
    }
}
