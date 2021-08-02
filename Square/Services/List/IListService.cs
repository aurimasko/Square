using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.List
{
    public interface IListService
    {
        Task<Response<Models.List>> GetAsync(Guid? id);
        Task<Response<IEnumerable<Models.List>>> GetAsync();
        Task<Response<Models.List>> AddAsync(Models.List list);
        Task<Response<Models.List>> DeleteAsync(Guid? id);
    }
}
