using Square.Communications;
using Square.Repositories.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.List
{
    public class ListService : IListService
    {
        private readonly IListRepository _repository;

        public ListService(IListRepository repository) { _repository = repository; }

        public async Task<Response<Models.List>> GetAsync(Guid? id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Response<IEnumerable<Models.List>>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Response<Models.List>> AddAsync(Models.List list)
        {
            foreach(Models.Point point in list.Points)
                point.ListId = list.Id;
            
            return await _repository.AddAsync(list);
        }

        public async Task<Response<Models.List>> DeleteAsync(Guid? id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
