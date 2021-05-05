using System;

namespace ShapesLibrary
{
    public class Triangle : Shape
    {
        public Triangle(double a, double b, double c)
        {
            if ((a <= 0) || (b <= 0) || (c <= 0))
            {
                throw new ArgumentException();
            }
                
            A = a;
            B = b;
            C = c;
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public override double Area
        {
            get
            {
                var p = Perimeter / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        public override double Perimeter => A + B + C;
    }
}