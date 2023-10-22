using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public class PolyGenerator
    {
        private double[] AmplitudeJ { get; }

        private double[] FrequencyJ { get; }

        private double[] PhaseJ { get; }

        private int N { get; }

        public double[] Values { get; }

        public PolyGenerator(double[] a, double[] f, double[] p, int n, int signalsCount, Generator[] generator)
        {
            AmplitudeJ = a;
            FrequencyJ = f;
            PhaseJ = p;
            this.N = n;


            var signals = new List<double[]>();
            for (var i = 0; i < signalsCount; i++)
            {
                generator[i].Amplitude = a[i];
                generator[i].Frequency = f[i];
                generator[i].Phase = p[i];
                generator[i].N = n;
                generator[i].Generate();
                signals.Add(generator[i].Values);
            }

            Values = new double[n * 6];
            for (var i = 0; i < n * 6; i++)
            {
                Values[i] = 0;

                for (var j = 0; j < signalsCount; j++)
                {
                    Values[i] += signals[j][i];
                }
            }
        }
    }
}
