using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.Communications;
using Square.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Services.File
{
    public class FileService : IFileService
    {
        public async Task<Response<Models.FileResult>> ReadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return new Response<Models.FileResult>("File is not attached.");

            List<Models.Point> resultList = new List<Models.Point>();
            Boolean _skippedLines = false;

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var line = String.Empty;

                while (reader.Peek() >= 0)
                {
                    line = await reader.ReadLineAsync();
                    var coords = line.Split(' ');

                    if (coords.Length > 2 || !int.TryParse(coords[0], out int coordX) || !int.TryParse(coords[1], out int coordY) || resultList.Any(p => p.CoordX == coordX && p.CoordY == coordY) || coordX < -5000 || coordX > 5000 || coordY < -5000 || coordY > 5000)
                    {
                        _skippedLines = true;
                        continue;
                    }
                    resultList.Add(new Models.Point() { CoordX = coordX, CoordY = coordY });
                }
            }
            return new Response<Models.FileResult>(new Models.FileResult() { SkippedLines = _skippedLines, Points = resultList });
        }
    }
}
