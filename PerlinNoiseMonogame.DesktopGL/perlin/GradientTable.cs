using System;
using System.Collections.Generic;

namespace NoiseFunction
{
    public class GradientTable
    {
        int interval = 256;
        int dimension = 2;
        NoiseRandom random;
        List<int> table;
        List<double[]> vectors;

        public GradientTable(int interval, int dimension)
        {
            this.interval = interval;
            this.dimension = dimension;
            random = new NoiseRandom();

            table = new List<int>();
            for(int i=0;i<interval;i++)
            {
                table.Add(random.Next(interval));
            }
            random_unit_vector(interval);
        }

        public void random_unit_vector(int interval)
        {
            vectors = new List<double[]>();
            double[] v;
            for(int i=0; i<interval;i++)
            {
                while(true)
                {
                    v = new double[] { random.rand() * 2 -1, random.rand() * 2 -1 };
                    if ( Magnitude(v) > 0 && Magnitude(v) <= 1)
                        break;
                }
                var vector_elements = new double[] { v[0] / Magnitude(v), v[1] / Magnitude(v) };
                vectors.Add(new double[] { vector_elements[0], vector_elements[1] });
            }
        }

        public double Magnitude(double[] v) 
        {
            var x = Math.Pow(v[0], 2);
            var y = Math.Pow(v[1], 2);
            return Math.Sqrt(x + y);
        }

        public double[] Vectors(int[] coords)
        {
            return vectors[index(coords)];
        }

        private int index(int[] coords)
        {
            var s = coords[1];
            s = perm(s) + reverse(coords)[1];
            return perm(s);
        }

        private int perm(int i)
        {
            return table[i % @interval];
        }

        private int[] reverse(int[] array)
        {
            int[] reverse = new int[] { array[0], array[1] };
            Array.Reverse(reverse);
            return reverse;
        }
    }
}