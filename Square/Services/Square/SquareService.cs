using Square.Communications;
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

        public Response<SquareList> FindSquares(Models.Point[] points)
        {
            SquareList squares = new SquareList { Squares = new List<Models.Square>(), SquaresCount = 0 };
            Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();

            for (int i = 0; i < points.Length; i++)
                pointsDictionary[points[i].CoordX + "," + points[i].CoordY] = i;

            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double distance = points[i].GetDistanceBetweenPoints(points[j]);

                    string point1 = (points[i].CoordX + distance).ToString() + "," + (points[i].CoordY + distance).ToString();//++
                    string point1Opp2 = (points[i].CoordX - distance).ToString() + "," + (points[i].CoordY + distance).ToString(); // -+

                    string point2Opp3 = (points[j].CoordX + distance).ToString() + "," + (points[j].CoordY + distance).ToString();//++
                    string point2 = (points[j].CoordX - distance).ToString() + "," + (points[j].CoordY + distance).ToString(); //-+

                    //   string[] PointA = { (points[i].CoordX + distance).ToString() + "," + (points[i].CoordY + distance).ToString(), (points[i].CoordX - distance).ToString() + "," + (points[i].CoordY + distance).ToString() };
                    // string[] PointB = { (points[j].CoordX + distance).ToString() + "," + (points[j].CoordY + distance).ToString() , (points[j].CoordX - distance).ToString() + "," + (points[j].CoordY + distance).ToString() };

                    if ((pointsDictionary.TryGetValue(point1, out int value1) && pointsDictionary.TryGetValue(point2, out int value2)) || (pointsDictionary.TryGetValue(point1Opp2, out value1) && pointsDictionary.TryGetValue(point2Opp3, out value2))) //|| (dictionary.ContainsKey(point1Opp) && dictionary.ContainsKey(point2Opp)) )/*||
                    {
                        if (distance != points[value2].GetDistanceBetweenPoints(points[value1]))
                            continue;

                        Models.Square square = new Models.Square
                        {
                            Points = new List<Models.Point>
                            {
                                points[i],
                                points[j],
                                points[value1],
                                points[value2]
                            }
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

        public async Task<Response<SquareList>> FindSquares(Guid? listID)
        {
            var list = await _listService.GetAsync(listID);

            if (!list.IsSuccess)
                return new Response<SquareList>(list.Message);

            var squares = FindSquares(list.Content.Points.ToArray());

            if (!squares.IsSuccess)
                return new Response<SquareList>(squares.Message);

            return squares;

        }
    }
}
