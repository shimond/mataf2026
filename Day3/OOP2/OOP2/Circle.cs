using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class Circle :Shape
    {
        public double Radius { get; set; }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
