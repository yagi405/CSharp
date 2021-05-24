namespace AbstractInterface.ExerciseOne
{
    public class Triangle : Shape
    {
        public double Bottom { get; }
        public double Height { get; }

        public Triangle(double bottom, double height)
        {
            Bottom = bottom;
            Height = height;
        }

        public override string Name { get { return "三角形"; } }

        public override double CalculateArea()
        {
            return Bottom * Height / 2;
        }

    }
}
