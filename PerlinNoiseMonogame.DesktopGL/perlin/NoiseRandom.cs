namespace NoiseFunction
{
    public class NoiseRandom
    {
        System.Random random = new System.Random();

        public int Next(int inteval)
        {
            return random.Next(inteval);
        }

        public double rand()
        {
            return random.NextDouble() % 1;
        }

    }
}