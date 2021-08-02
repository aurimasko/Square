using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Communications
{
    public class Response<T>
    {
        public T Content { get; }
        public bool IsSuccess { get; }
        public string Message { get; }

        public Response(bool _IsSuccess)
        {
            IsSuccess = _IsSuccess;
        }
        public Response(T _content) { Content = _content; IsSuccess = true; }
        public Response(string _Message) { IsSuccess = false; Message = _Message; }
        public Response(bool _IsSuccess, string _Message)
        {
            IsSuccess = _IsSuccess;
            Message = _Message;
        }
    }
}
