using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class Layer
    {
        private List<Neuron> neurons;

        public void Clear()
        {
            neurons.Clear();
        }
        public void Initialize(int nNeurons)
        {
            int i;
            for (i = 0; i < nNeurons; i++)
            {
                neurons.Add(new Neuron());
            }
        }

        public Neuron getNeuron(int index)
        {
            return neurons[index];
        }
        public void setNeuron(int index, ref Neuron neuron)
        {
            neurons[index] = neuron;
        }
        public void setNeuron(int index, Double value)
        {
            Neuron n = new Neuron();
            n.Value = value;
            neurons[index] = n;
        }

        public void AddDendritesToEachNeuron(int nDendrites, Random rnd)
        {
            int i;
            for (i = 0; i < neurons.Count; i++)
            {
                neurons[i].AddDendrites(nDendrites, rnd);
            }
        }

        public int nNeurons()
        {
            return neurons.Count;
        }



        /// <summary>
        /// Constructor of the class
        /// </summary>
        public Layer()
        {
            neurons = new List<Neuron>();
        }
    }
}
