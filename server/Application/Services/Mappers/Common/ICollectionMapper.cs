using System.Collections.Generic;

namespace Application.Services.Mappers
{
    public interface ICollectionMapper<From, To>: IMapper<From, To>
    {
        ICollection<To> Map(ICollection<From> fromCollection);
    }
}