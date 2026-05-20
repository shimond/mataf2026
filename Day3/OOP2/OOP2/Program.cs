using System.Data.Common;
using System.Data.SqlClient;

namespace OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shape s = new Shape();
            Triangle triangle = new Triangle()
            {
                Id = 1,
                Base = 10,
                Height = 10
            };
            Rectangle rectangle = new Rectangle()
            {
                Id = 10,
                Width = 10,
                Height = 10
            };

            Circle circle = new Circle()
            {
                Id = 100,
                Radius = 10
            };

            Shape[] shapes = new Shape[] { triangle, rectangle, circle };
            var totalArea = GetTotalArea(shapes);
            Console.WriteLine($"Total Area: {totalArea}");

        }
        static double GetTotalArea(Shape[] shapes)
        {
            
            int [] arr = new int[] { 1, 5, 3, 7, 8, 9 };
            
            foreach(int item in arr)
            {
                Console.WriteLine(item);
            }

            double sum = 0;
            foreach (var shape in shapes) { 
                sum += shape.GetArea();
            }

            for (int i = 0; i < shapes.Length; i++)
            {
                sum += shapes[i].GetArea();
            }
            return sum;
        }


    }
}
