using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInterface.ExerciseOne
{
    public class Shape
    {
        public virtual string Name { get { return "図形"; } }

        protected Shape() { }

        public virtual double CalculateArea()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"[{Name}] 面積: {CalculateArea()}";
        }
    }
}
