using System.Collections;
using System.Collections.Generic;

namespace Application.Services.Mappers
{
    public interface IMapper<From, To>
    {
        To Map(From fromType);
    }
}