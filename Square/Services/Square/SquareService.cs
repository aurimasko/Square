using Square.Communications;
using Square.DTO;
using Square.Extensions;
using Square.Models;
using Square.Services.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.Square
{
    public class SquareService : ISquareService
    {
        private readonly IListService _listService;

        public SquareService(IListService listService)
        {
            _listService = listService;
        }

        public Response<SquareList> FindSquares(IEnumerable<Models.SquarePoint> points)
        {
            //var pointsArray = points.OrderByDescending(p => p.CoordX).ThenBy(p => p.CoordY).ToArray();
            var pointsArray = points.ToArray();

            SquareList squares = new SquareList();

            HashSet<SquarePoint> pointsHash = new HashSet<SquarePoint>();

            for (int i = 0; i < pointsArray.Length; i++)
                pointsHash.Add(new SquarePoint { CoordX = pointsArray[i].CoordX, CoordY = pointsArray[i].CoordY });

            for (int i = 0; i < pointsArray.Length - 1; i++)
            {
                for (int j = i + 1; j < pointsArray.Length; j++)
                {
                    SquarePoint pointA = pointsArray[i];
                    SquarePoint pointB = pointsArray[j];

                    double distance = pointsArray[i].GetDistanceBetweenPoints(pointsArray[j]);

                    if (distance % 1 != 0) // if distance is not integer, then it is not possible to get integer coordinate
                        continue;

                    int lineLength = Convert.ToInt32(distance);

                    SquarePoint pointC = new SquarePoint { CoordX = pointB.CoordX, CoordY = pointB.CoordY + lineLength };
                    SquarePoint pointD = new SquarePoint { CoordX = pointA.CoordX, CoordY = pointA.CoordY + lineLength };

                    var diagonalDistance = distance * Math.Sqrt(2);

                    if (pointsHash.Contains(pointC) && pointsHash.Contains(pointD) && diagonalDistance.AboutEqual(pointC.GetDistanceBetweenPoints(pointA)) && diagonalDistance.AboutEqual(pointD.GetDistanceBetweenPoints(pointB)))
                    {

                        List<SquarePoint> square = new List<SquarePoint>
                        {
                            pointA,
                            pointB,
                            pointC,
                            pointD
                        };

                        if (!squares.Squares.Any(s => s == square))
                        {
                            squares.Squares.Add(square);
                            squares.SquaresCount++;
                        }
                    }
                }
            }
            return new Response<SquareList>(squares);
        }
    }
}
