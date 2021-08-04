using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Models
{
    public class FileResult
    {
        public IEnumerable<Models.Point> Points { get; set; }
        public Boolean SkippedLines { get; set; }
    }
}
