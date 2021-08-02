using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Repositories.Point
{
    public interface IPointRepository
    {
        Task<Response<Models.Point>> GetByIdAsync(Guid? id);
        Task<Response<Models.Point>> AddAsync(Models.Point point);
        Task<Response<Models.Point>> DeleteAsync(Guid? id);
}
