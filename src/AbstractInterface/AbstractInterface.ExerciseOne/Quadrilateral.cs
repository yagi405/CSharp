namespace AbstractInterface.ExerciseOne
{
    public class Quadrilateral : Shape
    {
        public double Heigth { get; }
        public double Width { get; }

        public Quadrilateral(double height, double width)
        {
            Heigth = height;
            Width = width;
        }

        public override string Name { get { return "四角形"; } }

        public override double CalculateArea()
        {
            return Heigth * Width;
        }
    }
}
