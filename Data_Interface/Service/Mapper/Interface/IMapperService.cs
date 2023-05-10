using System.Linq.Expressions;

namespace Data_Interface.Service.Mapper.Interface
{
    public interface IMapperService<TDto, TCto> where TDto : class where TCto : class
    {
        public TCto? ToCto(TDto? from);
        public TDto? ToDto(TCto? from);
        public Expression<Func<TDto, TCto>> ProjectToCto();
        public Expression<Func<TCto, TDto>> ProjectToDto();
    }
}
