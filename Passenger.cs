using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_AI
{
    class Passenger
    {
        public double klass, age, sex, survived;
        public Passenger(double klass, double age, double sex, double survived)
        {
            this.klass = klass;
            this.age = age;
            this.sex = sex;
            this.survived = survived;
        }
    }
}
