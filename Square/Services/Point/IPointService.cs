using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.Point
{
    public interface IPointService
    {
        Task<Response<Models.Point>> GetAsync(Guid? id);
        Task<Response<Models.Point>> AddAsync(Models.Point point);
        Task<Response<Models.Point>> DeleteAsync(Guid? id);
    }
}
