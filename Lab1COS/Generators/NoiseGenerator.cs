using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public class NoiseGenerator : Generator
    {
        private readonly Random _random = new Random();

        public NoiseGenerator(double a, double f, int n) : base(a, f, n)
        {
        }

        public NoiseGenerator(double a, double f, double p, int n) : base(a, f, p, n)
        {
        }

        public override double GetValue(int i)
        {
            return Amplitude * (_random.NextDouble() - 1);
        }

        public override double GetModulation(double extr, double i)
        {
            return Amplitude * (2 * _random.NextDouble() + - 1);
        }
    }
}
