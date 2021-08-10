using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Models
{
    public class SquarePoint
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public override int GetHashCode()
        {
            return CoordX.GetHashCode() + CoordY.GetHashCode();
        
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj is SquarePoint squarePoint)
            {
                equals = CoordX.Equals(squarePoint.CoordX) && CoordY.Equals(squarePoint.CoordY);
            }
            return equals;
        }
        public double GetDistanceBetweenPoints(SquarePoint pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.CoordX - this.CoordX, 2) + Math.Pow(pointB.CoordY - this.CoordY, 2));
        }
    }
}
