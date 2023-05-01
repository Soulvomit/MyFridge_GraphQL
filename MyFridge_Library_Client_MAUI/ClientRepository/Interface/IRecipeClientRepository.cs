using MyFridge_Library_Client_MAUI.ClientRepository.Interface.Base;
using MyFridge_Library_Client_MAUI.ClientModel;

namespace MyFridge_Library_Client_MAUI.ClientRepository.Interface
{
    public interface IRecipeClientRepository : IClientRepository<RecipeCto>
    {
        public IEnumerable<RecipeCto> MakeableLazies { get; }
        public Task<IEnumerable<RecipeCto>> GetMakeableAsync(int userId);
    }
}
