using System;

namespace ShapesLibrary
{
    public class Circle : Shape
    {
        public Circle(double r)
        {
            if (r <= 0)
            {
                throw new ArgumentException();
            }
            
            R = r;
        }
        
        public double R { get; private set; }

        public override double Area => Math.PI * R * R;
        public override double Perimeter => 2 * Math.PI * R;
    }
}