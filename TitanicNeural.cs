using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class TitanicNeural
    {
        Network ANN;
        Random rnd;
        static int nrTrainingCases = 1501;
        public TitanicNeural()
        {
            ANN = new Network();
            rnd = new Random();
            Initialize();
        }
        private void Initialize()
        {
            for (int i = 0; i < 3; i++)
                ANN.Layers.Add(new Layer());

            ANN.Layers[0].Initialize(4);
            ANN.Layers[1].Initialize(3);
            ANN.Layers[2].Initialize(1);
            ANN.Layers[0].AddDendritesToEachNeuron(2, rnd);
            ANN.Layers[1].AddDendritesToEachNeuron(1, rnd);
        }
        public void Training(List<Passenger> passengers)
        {
            double output;
            int i, it = 0, nrCorrect = 0, tempResult, nrSurvivorsCorrect = 0;
            List<double> input = new List<double>();
            while (it < 10)
            {
                for (i = 0; i < nrTrainingCases; i++)
                {
                    input.Add(passengers[i].klass);
                    input.Add(passengers[i].age);
                    input.Add(passengers[i].sex);
                    output = ANN.Analyze(input);
                    ANN.Training(passengers[i].survived, 0.1);
                    input.Clear();
                }
                it++;
            }
            for (i = nrTrainingCases; i < passengers.Count(); i++)
            {
                input.Add(passengers[i].klass);
                input.Add(passengers[i].age);
                input.Add(passengers[i].sex);
                output = ANN.Analyze(input);
                if (output > 0.5)
                {
                    tempResult = 1;
                    if (passengers[i].survived == 1)
                        nrSurvivorsCorrect++;
                }
                else
                    tempResult = 0;

                if (tempResult == passengers[i].survived)
                {
                    nrCorrect++;
                }
                else
                {
                    //Console.WriteLine();
                }
                input.Clear();
            }
            Console.WriteLine();
        }
    }
}
