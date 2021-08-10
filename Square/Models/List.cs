using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Models
{
    public class List
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Point.List))]
        public virtual IEnumerable<Point> Points { get; set; }
    }
}
