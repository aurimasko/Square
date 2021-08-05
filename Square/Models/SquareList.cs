using Square.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Models
{
    public class SquareList
    {
        public IList<Square> Squares { get; set; }
        public int SquaresCount { get; set; }
    }
}
