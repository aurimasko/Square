using Square.Communications;
using Square.Repositories.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.Point
{
    public class PointService : IPointService
    {
        private readonly IPointRepository repository;

        public PointService(IPointRepository _repository) { repository = _repository; }

        public async Task<Response<Models.Point>> GetAsync(Guid? id) 
        { 
            return await repository.GetByIdAsync(id);  
        }

        public async Task<Response<Models.Point>> AddAsync(Models.Point point)
        {
            if(point.CoordX < -5000) {
                return new Response<Models.Point>("X coordinate cannot be smaller than -5000");
            }

            if (point.CoordX > 5000) {
                return new Response<Models.Point>("X coordinate cannot be bigger than 5000");
            }

            if (point.CoordY < -5000) {
                return new Response<Models.Point>("Y coordinate cannot be smaller than -5000");
            }

            if (point.CoordY > 5000) {
                return new Response<Models.Point>("Y coordinate cannot be bigger than 5000");
            }

            // to do: get number of points in the list and check if it is not bigger than 10 000
            // to do: dont allow to add duplicate point

            return await repository.AddAsync(point);
        }

        public async Task<Response<Models.Point>> DeleteAsync(Guid? id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
