using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Communications
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Response() { }
        public Response(bool _IsSuccess)
        {
            IsSuccess = _IsSuccess;
        }
        public Response(string _Message) { IsSuccess = false; Message = _Message; }
        public Response(bool _IsSuccess, string _Message)
        {
            IsSuccess = _IsSuccess;
            Message = _Message;
        }
    }

    public class Response<T> : Response
    {
        public T Content { get; set; }

        public Response() { }

        public Response(bool _IsSuccess) : base(_IsSuccess) { }
   
        public Response(T _content) : base(true) { Content = _content; }
        public Response(string _Message) : base(_Message) {  }
        public Response(bool _IsSuccess, string _Message) : base(_IsSuccess, _Message) { }
    }
}
