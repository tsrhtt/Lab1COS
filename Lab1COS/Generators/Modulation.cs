using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Generators
{
    public class Modulation
    {
        public static double[] AmplitudeModulation(Generator mainGenerator, Generator modulisingGenerator)
        {
            mainGenerator.Generate();
            modulisingGenerator.Generate();

            if (mainGenerator.Values.Length != modulisingGenerator.Values.Length)
            {
                throw new Exception("Not equal langth");
            }

            var values = new double[mainGenerator.Values.Length];

            var max = modulisingGenerator.Values.Max(v => Math.Abs(v));
            for (var i = 0; i < mainGenerator.Values.Length; i++)
            {
                values[i] = mainGenerator.Values[i] * (1 + modulisingGenerator.Values[i]);
            }

            return values;
        }

        public static double[] FrequencyModulation(Generator mainGenerator, Generator modulisingGenerator)
        {
            modulisingGenerator.Generate();
            mainGenerator.Values = new double[modulisingGenerator.Values.Length];
            mainGenerator.Phase = 0;
            var sum = 0.0;

            for (var i = 0; i < modulisingGenerator.Values.Length; i++)
            {
                //var sum = modulisingGenerator.Values.Take(i).Select(v => 1 + v).Sum();
                sum += 1 + modulisingGenerator.Values[i];
                mainGenerator.Values[i] = mainGenerator.GetModulation(sum, i);
            }

            return mainGenerator.Values;
        }
    }
}
