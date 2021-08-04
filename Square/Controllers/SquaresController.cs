using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Square.Extensions;
using Square.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using FileResult = Microsoft.AspNetCore.Mvc.FileResult;

namespace Square.Controllers
{
    public class SquarePoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    [Route("[controller]")]
    [ApiController]
    public class SquaresController : ControllerBase
    {

        public SquaresController()
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Models.Point[] points)
        {
            List<Models.Square> squares = new List<Models.Square>();
            Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();
            int squaresCount = 0;

            for (int i = 0; i < points.Length; i++)
                pointsDictionary[points[i].CoordX +","+ points[i].CoordY] = i;
            
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

                    if((pointsDictionary.TryGetValue(point1, out int value1) && pointsDictionary.TryGetValue(point2, out int value2)) || (pointsDictionary.TryGetValue(point1Opp2, out value1) && pointsDictionary.TryGetValue(point2Opp3, out value2))  ) //|| (dictionary.ContainsKey(point1Opp) && dictionary.ContainsKey(point2Opp)) )/*||
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

                        if (!squares.Any(s => s == square))
                        {
                            squares.Add(square);
                            squaresCount++;
                        }
                    }
                }
            }
            return Ok(new { squaresCount, squares });
        }
    }
}