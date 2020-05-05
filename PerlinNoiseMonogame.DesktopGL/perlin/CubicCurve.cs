using System;

namespace NoiseFunction
{
    public class CubicCurve
    {
        public static Func<double, double> cubic = (t) => (double)(3 * Math.Pow(t, 2) - 2 * Math.Pow(t, 3));

        public static double Contrast(double n)
        {
            for (int i=0; i <= 2; i++ ) {
                n = cubic(n);
            }
            return n;
        }
    }
}