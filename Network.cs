using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class Network
    {
        private List<Layer> layers;
        internal List<Layer> Layers { get => layers; set => layers = value; }

        public Network()
        {
            Layers = new List<Layer>();
        }
        public double ActivationFunction(double value)  // sigmoid activationfunction
        {
            return 1 / (1 + Math.Exp(-value));

        }
        private List<double> calcFrontierValues(Layer frontierLayer, Layer parentLayer)   // equation for calculating frontier values
        {
            List<double> frontier = new List<double>();
            double tempValue;
            int i, j;
            for (j = 0; j < (frontierLayer.nNeurons() - 1); j++)
            {
                tempValue = 0;
                for (i = 0; i < parentLayer.nNeurons() - 1; i++)  //last one in layer is bias
                    tempValue += parentLayer.getNeuron(i).Value * parentLayer.getNeuron(i).getDendrite(j).Weight;

                tempValue += parentLayer.getNeuron(i).getDendrite(j).Weight; // since bias is 1, only the weight is added
                frontier.Add(tempValue);
            }
            return frontier;
        }
        public double Analyze(List<double> input)
        {
            if (input.Count() != (Layers[0].nNeurons() - 1))  // if wrong nr of inputs exit with error code
                return 0.0;

            int i, j = 0;
            List<double> frontier;

            for (i = 0; i < input.Count(); i++)
            {                                               //feed the input
                Layers[0].getNeuron(i).Value = input[i];
            }

            for (i = 1; i < (Layers.Count - 1); i++)    //push through network
            {
                frontier = calcFrontierValues(Layers[i], Layers[(i - 1)]);
                for (j = 0; j < (Layers[i].nNeurons() - 1); j++)
                {
                    Layers[i].getNeuron(j).Value = ActivationFunction(frontier[j]);
                }
            }

            double output = 0;      // for output layer
            for (int k = 0; k < Layers[(i - 1)].nNeurons() - 1; k++)
                output += Layers[(i - 1)].getNeuron(k).Value * Layers[(i - 1)].getNeuron(k).getDendrite(0).Weight;

            output += Layers[(i - 1)].getNeuron(2).getDendrite(0).Weight;  // also add bias
            Layers[i].getNeuron(0).Value = ActivationFunction(output);


            return Layers[i].getNeuron(0).Value;
        }
        public void Training(double actual, double learningrate)
        {
            int currentLayer = layers.Count() - 1;
            double error = actual - layers[currentLayer].getNeuron(0).Value;
            calcDeltas(error);
            calcGradients(learningrate);
            calcNewWeights();
        }
        public void calcDeltas(double error)
        {
            int currentLayer = layers.Count() - 1;
            layers[currentLayer].getNeuron(0).Delta = error * (layers[currentLayer].getNeuron(0).Value * (1 - layers[currentLayer].getNeuron(0).Value));
            for (int i = currentLayer - 1; i > 0; i--)
            {
                for (int j = 0; j < (layers[i].nNeurons() - 1); j++)
                {                                                                   //skip delta for input level and biases
                    layers[i].getNeuron(j).Delta =
                        layers[i].getNeuron(j).Value * (1 - layers[i].getNeuron(j).Value)
                        * layers[i].getNeuron(j).getDendrite(0).Weight
                        * layers[currentLayer].getNeuron(0).Delta;
                }
            }
        }
        public void calcGradients(double learningrate)
        {
            int i, j, k;
            for(i = 0; i < (Layers.Count() - 1); i++)
            {
                for(j = 0; j < Layers[i].nNeurons(); j++)
                {
                    for(k = 0; k < Layers[i].getNeuron(j).nDendrites(); k++)
                    {
                        Layers[i].getNeuron(j).getDendrite(k).Gradient = learningrate *
                            Layers[(i + 1)].getNeuron(k).Delta *
                            Layers[i].getNeuron(j).Value;
                    }
                }
            }
        }
        public void calcNewWeights()
        {
            int i, j, k;

            for (i = (Layers.Count() - 2); i >= 0; i--)                           //calculate new weights starting at output layer - 1
            {
                for (j = 0; j < Layers[i].nNeurons(); j++)
                {
                    for (k = 0; k < Layers[i].getNeuron(j).nDendrites(); k++)
                    {
                        Layers[i].getNeuron(j).getDendrite(k).Weight
                            += Layers[i].getNeuron(j).getDendrite(k).Gradient;
                    }
                }
            }
        }
    }
}
