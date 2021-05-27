using System;

namespace AbstractInterface.ExerciseOne
{
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string Name { get { return "円"; } }

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }
    }
}
