using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.Square
{
    public interface ISquareService
    {
        Response<Models.SquareList> FindSquares(Models.Point[] points);
        Task<Response<Models.SquareList>> FindSquares(Guid? listID);
    }
}
