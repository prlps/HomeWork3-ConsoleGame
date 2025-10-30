using System;

namespace HomeWork3_ConsoleGame
{
    public static class RandomHelper
    {
        private static readonly Random rnd = new Random();

        public static int NextInt(int minInclusive, int maxExclusive) => rnd.Next(minInclusive, maxExclusive);
        public static double NextDouble() => rnd.NextDouble();

        // Нормальное распределение, ограниченное min/max
        public static int NormalClamped(int mean, double stddev, int min, int max)
        {
            double u1 = 1.0 - rnd.NextDouble();
            double u2 = 1.0 - rnd.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            int value = (int)Math.Round(mean + randStdNormal * stddev);
            return Math.Clamp(value, min, max);
        }

        // Нормальное с критическим шансом
        public static int NormalWithCrit(int mean, double stddev, int min, int max, double critProb = 0.08, double critMultiplier = 2.0)
        {
            if (rnd.NextDouble() < critProb)
            {
                // Критический удар: множим среднее на critMultiplier, потом clamp
                int critDamage = (int)Math.Round(mean * critMultiplier);
                return Math.Clamp(critDamage, min, max);
            }
            return NormalClamped(mean, stddev, min, max);
        }
    }
}
