using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    internal class Triangle : Shape
    {
        public int Base { get; set; }
        public int Height { get; set; }

        public override double GetArea()
        {
            return 0.5 * Base * Height;
        }

        public override double GetPerimeter()
        {
            // For simplicity, we will assume it's an equilateral triangle
            return 3 * Base;
        }


    }
}
