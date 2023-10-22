using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public class SawToothGenerator : Generator
    {
        public SawToothGenerator(double a, double f, int n) : base(a, f, n)
        {
        }

        public SawToothGenerator(double a, double f, double p, int n) : base(a, f, p, n)
        {
        }

        public override double GetValue(int i)
        {
            return -2 * Amplitude / Math.PI * Math.Atan(1 / Math.Tan(Math.PI * Frequency * i / N + Phase));
        }

        public override double GetModulation(double extr, double i)
        {
            return -2 * Amplitude / Math.PI * Math.Atan(1 / Math.Tan(Math.PI * Frequency * extr * 1 / N + Phase));
        }
    }
}
