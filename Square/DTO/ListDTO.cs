using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.DTO
{
    public class ListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PointDTO> Points { get; set; }
    }
}
