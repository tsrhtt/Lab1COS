using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public class TriangleGenerator : Generator
    {
        public TriangleGenerator(double a, double f, int n) : base(a, f, n)
        {
        }

        public TriangleGenerator(double a, double f, double p, int n) : base(a, f, p, n)
        {
        }

        public override double GetValue(int i)
        {
            return 2 * Amplitude / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * Frequency * i / N + Phase));
        }

        public override double GetModulation(double extr, double i)
        {
            return 2 * Amplitude / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * Frequency * extr * 1 / N + Phase));
        }
    }
}
