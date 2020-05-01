using System;
using System.Collections.Generic;

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

        public double GetPoint(double x, double y)
        {
            var coords = new double[] { x, y };
            var cell = new int[] { (int)coords[0], (int)coords[1] };
            var diff = new double[] { coords[0] - cell[0], coords[1] - cell[1] };

            // Calculate noise factor at each surrouning vertex
            var noise_factor = new Dictionary<int[], double>();

            Action<int[]> calc_noise_factory = (idx) => {
                idx = new int[2] { idx[0], idx[1] };
                var scalar_gradient_point = new int[] { cell[0] + idx[0], cell[1] + idx[1] };
                var gv = GradientTable.Vectors(scalar_gradient_point);
                noise_factor.Add(idx, inner_product(gv, subtract(diff, idx)));
            };
            iterate(Dimensaion, 2, calc_noise_factory);
        }

        private void iterate(int dim, int length, Action<int[]> block)
        {
            iterate_recursive(dim, length, new int[dim], block);
        }

        private void iterate_recursive(int dim, int length, int[] idx, Action<int[]> block)
        {
            for(int i=0;i<length;i++)
            {
                idx[dim - 1] = i;
                if (dim == 1)
                    block(idx);
                else
                    iterate_recursive(dim - 1, length, idx, block);
            }
        }

        private double inner_product(double[] vector1, double[] vector2)
        {
            var product_i = vector1[0] * vector2[0];
            var product_j = vector1[1] * vector2[1];
            return product_i + product_j;
        }

        private double[] subtract(double[] vector1, int[] vector2)
        {
            var dim = 2;
            double[] result = new double[dim];
            for (int i = 0; i < dim; i++)
            {
                result[i] = vector1[i] - vector2[i];
            }
            return result;
        }
    }
}