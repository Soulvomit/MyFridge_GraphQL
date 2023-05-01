using Client_Library.Interface.Base;
using Client_Model;

namespace Client_Library.Interface
{
    public interface IRecipeClientRepository : IClientRepository<RecipeCto>
    {
        public IEnumerable<RecipeCto> MakeableCache { get; }
        public Task<IEnumerable<RecipeCto>> GetMakeableAsync(int userId);
    }
}
