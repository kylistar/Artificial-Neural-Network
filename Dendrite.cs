using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class Dendrite
    {
        private double wt, gradient;
        public double Weight
        {
            get { return wt; }
            set { wt = value; }
        }

        public double Gradient { get => gradient; set => gradient = value; }

        public Dendrite(Random rnd)
        {
            wt = getRandom(0.00000001, 1.0, rnd);
        }

        private double getRandom(double MinValue, double MaxValue, Random rnd)
        {
            return (rnd.NextDouble()) * (MaxValue - MinValue) + MinValue;
        }
    }
}
