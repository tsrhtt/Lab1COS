using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public class DifferentDutyCycle : Generator
    {
        private double WorkingCycle { get; }

        public DifferentDutyCycle(double a, double f, int n, double workingCycle) : base(a, f, n)
        {
            WorkingCycle = workingCycle;
        }

        public DifferentDutyCycle(double a, double f, double p, int n, double workingCycle) : base(a, f, p, n)
        {
            WorkingCycle = workingCycle;
        }

        public override double GetValue(int i)
        {
            var T = 1 / Frequency;
            var t = (double)i / N;
            var modT = t % T;

            var value = (modT / T < WorkingCycle) ? Amplitude : -Amplitude;
            return value;
        }


        public override double GetModulation(double extr, double i)
        {
            var T = 1 / Frequency;
            var sin = (((double)1.0 * extr / N) % T) / (double)T;
            return Amplitude * (sin >= WorkingCycle ? -1 : 1);
        }
    }
}
