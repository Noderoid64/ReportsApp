using System.Collections.Generic;

namespace Application.Services.Mappers
{
    public interface IBiCollectionMapper<From, To> : IBiMapper<From, To>, ICollectionMapper<From, To>
    {
        ICollection<From> MapBack(ICollection<To> fromCollection);
    }
}