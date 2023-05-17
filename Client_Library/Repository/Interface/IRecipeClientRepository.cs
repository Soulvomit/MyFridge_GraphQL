using Client_Library.Repository.Interface.Base;
using Client_Model.GraphQL.Response;
using Client_Model.Model;

namespace Client_Library.Repository.Interface
{
    public interface IRecipeClientRepository : IClientRepository<RecipeCto>
    {
        public IEnumerable<RecipeCto> CachedMakeableItems { get; }
        public Task<(IEnumerable<RecipeCto>, PageInfo)> GetMakeableAsync(
            string pagination,
            string filter,
            string sort,
            string nodeItems,
            string pageInfoItems);
    }
}
