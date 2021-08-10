using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.Square
{
    public interface ISquareService
    {
        Response<Models.SquareList> FindSquares(IEnumerable<Models.SquarePoint> points2);
    }
}
