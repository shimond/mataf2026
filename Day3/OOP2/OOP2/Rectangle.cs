using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{

    public abstract class Shape
    {
        public int Id { get; set; }
        public abstract double GetPerimeter();
        public abstract double GetArea();
    }
    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
        public override double GetArea()
        {
            return Width * Height;
        }
    }
}
