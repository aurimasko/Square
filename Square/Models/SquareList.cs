using Square.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Models
{
    public class SquareList
    {
        public SquareList()
        {
            Squares = new List<IEnumerable<SquarePoint>>();
            SquaresCount = 0;
        }
        public IList<IEnumerable<SquarePoint>> Squares { get; set; }
        public int SquaresCount { get; set; }
    }
}
