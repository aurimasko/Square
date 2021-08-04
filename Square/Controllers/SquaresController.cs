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

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            int count = 0;

            for (int i = 0; i < points.Length; i++)
            {
                dictionary[points[i].CoordX +","+ points[i].CoordY] = i;
            }

            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    var distance = Math.Sqrt(Math.Pow(points[j].CoordX - points[i].CoordX, 2) + Math.Pow(points[j].CoordY - points[i].CoordY, 2));

                    var point1X = points[i].CoordX + distance;
                    var point1Y = points[i].CoordY + distance;

                    var point1OppX = points[i].CoordX - distance;
                    var point1OppY = points[i].CoordY - distance;


                     var point2X = points[j].CoordX - distance;
                     var point2Y = points[j].CoordY + distance;

                    var point2OppX = points[j].CoordX + distance;
                     var point2OppY = points[j].CoordY - distance;


                    string point1 = point1X.ToString() + "," + point1Y.ToString();//++
                    string point1Opp2 = (points[i].CoordX - distance).ToString() + "," + (points[i].CoordY + distance).ToString(); // -+

                    string point2Opp3 = (points[j].CoordX + distance).ToString() + "," + (points[j].CoordY + distance).ToString();//++
                    string point2 = point2X.ToString() + "," + point2Y.ToString(); //-+


                        int value1, value2;


                    if((dictionary.TryGetValue(point1, out value1) && dictionary.TryGetValue(point2, out value2)) || (dictionary.TryGetValue(point1Opp2, out value1) && dictionary.TryGetValue(point2Opp3, out value2))  ) //|| (dictionary.ContainsKey(point1Opp) && dictionary.ContainsKey(point2Opp)) )/*||
                    {
                        var distance2 = Math.Sqrt(Math.Pow(points[value1].CoordX - points[value2].CoordX, 2) + Math.Pow(points[value1].CoordY - points[value2].CoordY, 2));

                        if (distance != distance2)
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
                                count++;
                            }
                    }
                }
            }
            return Ok(squares);
        }
    }
}