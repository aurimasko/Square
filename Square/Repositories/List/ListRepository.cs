using Microsoft.EntityFrameworkCore;
using Square.Communications;
using Square.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Repositories.List
{
    public class ListRepository : IListRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public ListRepository(ApplicationDatabaseContext context) { _context = context; }

        public async Task<Response<Models.List>> GetAsync(Guid? id)
        {
            return new Response<Models.List>(await _context.Lists.Include(l => l.Points).FirstOrDefaultAsync(l => l.Id.Equals(id)));
        }

        public async Task<Response<IEnumerable<Models.List>>> GetAsync()
        {
            return new Response<IEnumerable<Models.List>>(await _context.Lists.Include(l => l.Points).ToListAsync());
        }

        public async Task<Response<Models.List>> AddAsync(Models.List list)
        {
            var entity = await _context.Lists.AddAsync(list);

            if (entity.Entity == null)
                return new Response<Models.List>("New list was not added");

            if (await _context.SaveChangesAsync() > 0)
                return new Response<Models.List>(entity.Entity);

            return new Response<Models.List>("New list was not saved.");
        }

        public async Task<Response<Models.List>> DeleteAsync(Guid? id)
        {
            var entity = await GetAsync(id);

            if (entity.Content == null)
                return new Response<Models.List>("There is no list with given ID.");

            var delete = _context.Lists.Remove(entity.Content);

            if (await _context.SaveChangesAsync() > 0)
                return new Response<Models.List>(delete.Entity);

            return new Response<Models.List>("List was not deleted.");
        }
    }
}
