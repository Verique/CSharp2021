using System;

namespace RectangleHelper {
    public static class AreaPerimeter {

        public static int Area(int a, int b) {
            if (a <= 0 || b <= 0)
                throw new ArgumentOutOfRangeException();
            else return a * b;
        }

        public static int Perimeter(int a, int b) {
            if (a <= 0 || b <= 0)
                throw new ArgumentOutOfRangeException();
            else return 2*(a+b); 
        }
    }
}