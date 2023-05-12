using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model.Model;

namespace Client_Library.Repository
{
    public class IngredientAmountClientRepository : ClientRepository<IngredientAmountCto>, IIngredientAmountClientRepository
    {
        public IngredientAmountClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
