using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model.Model;

namespace Client_Library.Repository
{
    public class IngredientClientRepository : ClientRepository<IngredientCto>, IIngredientClientRepository
    {
        public IngredientClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
