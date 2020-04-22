using System;
using System.Collections.Generic;
using System.Numerics;
using static System.Numerics.Vector2;

namespace NoiseFunction
{
    public class GradientTable
    {
        int interval = 256;
        int dimension = 2;
        Random random = new Random();
        float[] table;
        List<Vector2> vectors;

        public GradientTable(int interval, int dimension)
        {
            this.interval = interval;
            this.dimension = dimension;

            table = new float[] { random.Next(interval) };
            random_unit_vector(interval);
        }

        public List<Vector2> random_unit_vector(int interval)
        {
            vectors = new List<Vector2>();
            Vector2 v;
            while(true)
            {
                v = new Vector2(random.Next() * 2 -1, random.Next() * 2 -1);
                if ( Magnitude(v) > 0 && Magnitude(v) <= 1)
                    break;
            }
            var vector_elements = new float[] { v.X / Magnitude(v), v.Y / Magnitude(v) };
            for(int i=0; i<interval;i++)
            {
                vectors.Add(new Vector2(vector_elements[0], vector_elements[1]));
            }
            return vectors;
        }

        public float Magnitude(Vector2 v) 
        {
            var square_v = SquareRoot(v);
            return (float)Math.Sqrt(square_v.X + square_v.Y);
        }
    }
}