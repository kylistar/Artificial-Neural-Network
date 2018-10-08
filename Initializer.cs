using System.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class Initializer
    {
        public Initializer(List<Passenger> passengers)
        {
            ReadFromFile(passengers);
        }
        public void ReadFromFile(List<Passenger> passengers)
        {
            StreamReader reader = new StreamReader("C:/Users/Emil/Dropbox/Labb 4 AI/assignment 4 titanic.dat");
            string line;
            string[] parameters;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                parameters = line.Split(',');
                if (Equals(parameters[3].ToString(), "-1.0"))
                    parameters[3] = "0";

                
                passengers.Add(new Passenger(
                    Convert.ToDouble(parameters[0], CultureInfo.InvariantCulture), 
                    Convert.ToDouble(parameters[1], CultureInfo.InvariantCulture), 
                    Convert.ToDouble(parameters[2], CultureInfo.InvariantCulture), 
                    Convert.ToDouble(parameters[3], CultureInfo.InvariantCulture)
                    ));
            }
        }
    }
}
