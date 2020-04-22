using System;

namespace NoiseFunction
{
    public class PerlinNoise
    {
        public PerlinNoise(int interval = 256, int dimenstion = 2)
        {
            Interval = interval;
            Dimensaion = dimenstion;
            GradientTable = new GradientTable(Interval, Dimensaion);
        }

        public int Interval { get; }
        public int Dimensaion { get; }
        public GradientTable GradientTable { get; }
  }
}