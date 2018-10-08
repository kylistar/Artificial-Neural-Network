using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Passenger> passengers = new List<Passenger>();
            Initializer init = new Initializer(passengers);
            TitanicNeural titanicNeural = new TitanicNeural();
            titanicNeural.Training(passengers);


            Console.WriteLine();
        }
    }
}
