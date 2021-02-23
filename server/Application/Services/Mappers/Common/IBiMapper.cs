using System.Collections.Generic;

namespace Application.Services.Mappers
{
    public interface IBiMapper<From, To>: IMapper<From, To>
    {
        From MapBack(To fromType);
    }
}