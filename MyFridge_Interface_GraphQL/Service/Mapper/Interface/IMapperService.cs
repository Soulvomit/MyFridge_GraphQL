namespace MyFridge_Interface_GraphQL.Service.Mapper.Interface
{
    public interface IMapperService<TDto, TCto> where TDto : class where TCto : class
    {
        public TCto? ToCto(TDto? from);
        public TDto? ToDto(TCto? from);
    }
}
