using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Communications
{
    public class Response
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public Response(bool _IsSuccess)
        {
            IsSuccess = _IsSuccess;
        }

        public Response(bool _IsSuccess, string _Message)
        {
            IsSuccess = _IsSuccess;
            Message = _Message;
        }
    }

    public class Response<T> : Response
    { 
        public T Content { get; }

        public Response(T _content) : base(true) { Content = _content; }
        public Response(string _Message) : base(false, _Message) { }
    }
}
