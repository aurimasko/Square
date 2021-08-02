using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.DTO
{
    public class PointDTO
    {
        public Guid Id { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public Guid? ListId { get; set; }
    }
}
