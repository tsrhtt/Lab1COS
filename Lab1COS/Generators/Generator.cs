using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public abstract class Generator
    {
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        public double Phase { get; set; }
        public int N { get; set; }
        public double[] Values { get; set; }

        protected Generator(double a, double f, double p, int n)
        {
            Amplitude = a;
            Frequency = f;
            Phase = p;
            this.N = n;
        }

        protected Generator(double a, double f, int n)
        {
            Amplitude = a;
            Frequency = f;
            Phase = 0;
            this.N = n;
        }

        public void Generate()
        {
            Values = GetValues();
        }

        private double[] GetValues()
        {
            var values = new double[N * 6];
            for (var i = 0; i < N * 6; i++)
            {
                values[i] = GetValue(i);
            }
            return values;
        }

        public abstract double GetValue(int i);

        public abstract double GetModulation(double extr, double i);

        public double[] GetPolyHarmonic(double[] phases)
        {
            var values = new double[1];
            return values;
        }
    }
}
