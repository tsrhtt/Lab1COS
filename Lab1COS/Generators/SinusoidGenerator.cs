using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public class SinusoidGenerator : Generator
    {
        public SinusoidGenerator(double a, double f, int n) : base(a, f, n)
        {
        }

        public SinusoidGenerator(double a, double f, double p, int n) : base(a, f, p, n)
        {
        }

        public override double GetValue(int i)
        {
            return Amplitude * Math.Sin(2 * Math.PI * Frequency * i / N + Phase);
        }

        public override double GetModulation(double extr, double i)
        {
            return Amplitude * Math.Sin(2 * Math.PI * Frequency * extr * 1 / N + Phase);
        }
    }
}
