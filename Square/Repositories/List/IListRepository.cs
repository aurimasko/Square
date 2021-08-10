using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Repositories.List
{
    public interface IListRepository
    {
        Task<Response<Models.List>> GetAsync(Guid? id);
        Task<Response<Models.List>> GetByNameAsync(string name);
        Task<Response<IEnumerable<Models.List>>> GetAsync();
        Task<Response<Models.List>> AddAsync(Models.List list);

        Task<Response<Models.List>> DeleteAsync(Guid? id);
    }
}
