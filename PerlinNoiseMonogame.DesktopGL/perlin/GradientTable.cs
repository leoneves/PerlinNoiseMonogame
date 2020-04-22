using System;
using System.Collections.Generic;
using System.Numerics;

namespace NoiseFunction
{
    public class GradientTable
    {
        int interval = 256;
        int dimension = 2;
        NoiseRandom random;
        List<double> table;
        List<Vector2> vectors;

        public GradientTable(int interval, int dimension)
        {
            this.interval = interval;
            this.dimension = dimension;
            random = new NoiseRandom();

            table = new List<double>();
            for(int i=0;i<interval;i++)
            {
                table.Add(random.Next(interval));
            }
            random_unit_vector(interval);
        }

        public void random_unit_vector(int interval)
        {
            vectors = new List<Vector2>();
            Vector2 v;
            for(int i=0; i<interval;i++)
            {
                while(true)
                {
                    v = new Vector2((float)random.rand() * 2 -1, (float)random.rand() * 2 -1);
                    if ( Magnitude(v) > 0 && Magnitude(v) <= 1)
                        break;
                }
                var vector_elements = new double[] { v.X / Magnitude(v), v.Y / Magnitude(v) };
                vectors.Add(new Vector2((float)vector_elements[0], (float)vector_elements[1]));
            }
        }

        public double Magnitude(Vector2 v) 
        {
            var x = Math.Pow(v.X, 2);
            var y = Math.Pow(v.Y, 2);
            return Math.Sqrt(x + y);
        }
    }
}