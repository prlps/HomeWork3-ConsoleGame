using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_ConsoleGame
{
    public static class RandomHelper
    {
        private static readonly Random rnd = new Random();

        public static int NextInt(int minInclusive, int maxExclusive) => rnd.Next(minInclusive, maxExclusive);
        public static double NextDouble() => rnd.NextDouble();

        public static int NormalClamped(int mean, double stddev, int min, int max)
        {
            double u1 = 1.0 - rnd.NextDouble();
            double u2 = 1.0 - rnd.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            int value = (int)Math.Round(mean + randStdNormal * stddev);
            return Math.Clamp(value, min, max);
        }

        public static int NormalMixture(int mean, double stddev, int min, int max, double extremeProb = 0.08)
        {
            if (rnd.NextDouble() < extremeProb)
            {
                // экстремум: равномерно в диапазоне (можно изменить логику)
                return rnd.Next(min, max + 1);
            }
            return NormalClamped(mean, stddev, min, max);
        }
    }
}