using Microsoft.EntityFrameworkCore;
using Square.Communications;
using Square.Database;
using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Repositories.Point
{
    public class PointRepository : IPointRepository
    {
        private readonly ApplicationDatabaseContext DbContext;

        public PointRepository(ApplicationDatabaseContext _dbContext) { DbContext = _dbContext; }

        public async Task<Response<Models.Point>> GetByIdAsync(Guid? id)
        {
            // to do: add asnotracking()
            return new Response<Models.Point>(await DbContext.Points.AsQueryable().Where(p => p.Id.Equals(id)).FirstOrDefaultAsync());
        }
        public async Task<Response<Models.Point>> AddAsync(Models.Point point)
        {
            var entity = await DbContext.Points.AddAsync(point);

            if (entity.Entity == null)
                return new Response<Models.Point>("New point was not added");

            if (await DbContext.SaveChangesAsync() > 0)
                return new Response<Models.Point>(entity.Entity);

            return new Response<Models.Point>("New point was not added.");
        }
        public async Task<Response<Models.Point>> DeleteAsync(Guid? id)
        {
            var entity = await DbContext.Points.AsQueryable().Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
                return new Response<Models.Point>("There is no point with given ID.");

            var delete = DbContext.Points.Remove(entity);

            if (await DbContext.SaveChangesAsync() > 0)
                return new Response<Models.Point>(delete.Entity);

            return new Response<Models.Point>("Point was not deleted.");
        }

    }
}
