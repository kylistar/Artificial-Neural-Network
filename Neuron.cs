using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class Neuron
    {
        private List<Dendrite> dendrites;
        private double bias, delta, _value;

        public double Bias
        {
            get
            { return bias; }
            set
            { bias = value; }
        }
        public double Delta
        {
            get
            { return delta; }
            set
            { delta = value; }
        }
        public double Value
        {
            get
            { return _value; }
            set
            { _value = value; }
        }

        public void AddDendrites(int nDendrites, Random rnd)
        {
            for (int i = 0; i < nDendrites; i++)
            {
                dendrites.Add(new Dendrite(rnd));
            }
        }

        public int nDendrites()
        {
            return dendrites.Count;
        }

        public Dendrite getDendrite(int index)
        {
            return dendrites[index];
        }

        public Neuron()
        {
            bias = 1;  //rnd.Next(7);
            dendrites = new List<Dendrite>();
            _value = 0;
        }

    }
}
