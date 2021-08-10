using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.DTO
{
    public class FileResultDTO
    {
        public IEnumerable<DTO.PointDTO> Points { get; set; }
        public Boolean SkippedLines { get; set; }
    }
}
