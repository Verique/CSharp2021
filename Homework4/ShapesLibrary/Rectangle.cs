using System;

namespace ShapesLibrary
{
    public class Rectangle : Shape
    {
        public double Width { get; private set; }

        public double Height { get; private set; }
        
        public Rectangle(double width, double height)
        {
            if ((width <= 0) || (height <= 0))
            {
                throw new ArgumentException();
            }
            
            Width = width;
            Height = height;
        }

        public override double Area => Height * Width;
        public override double Perimeter => 2 * (Height + Width);
    }
}