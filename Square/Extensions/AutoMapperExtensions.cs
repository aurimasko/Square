using AutoMapper;
using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Square.Extensions
{
    public static class AutoMapperExtensions
    {
        public static Response<T> MapDTO<T, K>(this IMapper mapper, Response<K> response)
        {
            if (response.IsSuccess)
            {
                var mapped = mapper.Map<K, T>(response.Content);
                return new Response<T>(mapped);
            }
            else
            {
                T content = default(T);

                if (response.Content != null)
                    content = mapper.Map<K, T>(response.Content);

                return new Response<T>()
                {
                    Content = content,
                    Message = response.Message
                };
            }
        }
    }
}
