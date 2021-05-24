namespace AbstractInterface.ExerciseOne
{
    public class Square : Quadrilateral
    {
        public Square(double side) : base(side, side) { }

        public override string Name { get { return "正方形"; } }
    }
}
