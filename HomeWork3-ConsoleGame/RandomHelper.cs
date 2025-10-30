using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_ConsoleGame
{
    public static class RandomHelper
    {
        // Генерация нормального распределения (По гауссу)
        private static Random rnd = new Random();

        public static int Normal(int mean, double stddev)
        {
            double u1 = 1.0 - rnd.NextDouble();
            double u2 = 1.0 - rnd.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            int value = (int)Math.Round(mean + randStdNormal * stddev);
            return Math.Max(0, value);
        }
    }

}
