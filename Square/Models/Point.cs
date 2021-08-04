﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Models
{
    public class Point
    {
        public Point() { }

        [Key]
        public Guid Id { get; set; }

        public int CoordX { get; set; }

        public int CoordY { get; set; }

        public Guid? ListId { get; set; }

        [ForeignKey(nameof(ListId))]
        public List List { get; set; }

        public double GetDistanceBetweenPoints(Point pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.CoordX - this.CoordX, 2) + Math.Pow(pointB.CoordY - this.CoordY, 2));
        }
    }
}
