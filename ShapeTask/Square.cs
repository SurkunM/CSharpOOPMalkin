using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    internal class Square : IShape
    {
        private const int sidesCount = 4;

        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public double GetPerimeter()
        {
            return SideLength * sidesCount;
        }

        public override string ToString()
        {
            return GetArea().ToString();
        }
    }
}
