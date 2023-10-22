using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Model
{
    public class InputModel
    {
        public double[] A { get; set; } = new double[5];
        public double[] F { get; set; } = new double[5];
        public double[] Fi { get; set; } = new double[5];
        public double[] WorkingCycle { get; set; }
        public int N { get; set; } = 44100;
    }
}
