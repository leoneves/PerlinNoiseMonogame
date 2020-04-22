using System;

namespace NoiseFunction
{
    public class CubicCurve
    {
        static Func<float, float> cubic = (t) => (float)(3 * Math.Pow(t, 2) - 2 * Math.Pow(t, 3));

        public static float Contrast()
        {
            var n = 0f;
            for (int i=0; i <= 2; i++ ) {
                n = cubic(i);
            }
            return n;
        }
    }
}