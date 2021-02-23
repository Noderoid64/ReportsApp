namespace Application.Services.Mappers
{
    public interface IMapper<From, To>
    {
        To Map(From fromType);
    }
}