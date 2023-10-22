using Lab1COS.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Utils
{
    public static class SignalFabric
    {
        public static Generators.Generator GetGenerator(string signal, double a, double f, double p, double workingCycle, int n)
        {
            switch (signal)
            {
                case "синусоида":
                    return new SinusoidGenerator(a, f, p, n);
                case "треугольная":
                    return new TriangleGenerator(a, f, p, n);
                case "пилообразная":
                    return new SawToothGenerator(a, f, p, n);
                //case "шум":
                    //return new NoiseGenerator(a, f, p, n);
                case "прямоугольная":
                    return new DifferentDutyCycle(a, f, p, n, workingCycle);
                default:
                    break;
            }

            return null;
        }
    }
}
