using System;

namespace AbstractInterface.ExerciseOne
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var shapes = new Shape[]
            {
                new Circle(1),
                new Circle(2.5),
                new Circle(100),
                new Triangle(2,5),
                new Triangle(1.5,3),
                new Triangle(10,20),
                new Quadrilateral(10,20),
                new Quadrilateral(2.5,4),
                new Quadrilateral(20,5),
                new Square(5),
                new Square(3.5),
                new Square(10),
            };

            PrintShapes(shapes);

            //error
            //var shape = new Shape();
            //Console.WriteLine(shape.CalculateArea());
        }

        private static void PrintShapes(Shape[] shapes)
        {
            if (shapes is null)
            {
                return;
            }

            foreach (var shape in shapes)
            {
                Console.WriteLine("------------------");
                Console.WriteLine($"{nameof(shape.Name)}:{shape.Name}");
                switch (shape)
                {
                    case Circle c:
                        Console.WriteLine($"{nameof(c.Radius)}:{c.Radius}");
                        break;
                    case Triangle t:
                        Console.WriteLine($"{nameof(t.Bottom)}:{t.Bottom}");
                        Console.WriteLine($"{nameof(t.Height)}:{t.Height}");
                        break;
                    case Square s:
                        Console.WriteLine($"{nameof(s.Width)}:{s.Width}");
                        break;
                    case Quadrilateral q:
                        Console.WriteLine($"{nameof(q.Heigth)}:{q.Heigth}");
                        Console.WriteLine($"{nameof(q.Width)}:{q.Width}");
                        break;
                }
                Console.WriteLine($"{nameof(shape.CalculateArea)} => {shape.CalculateArea()}");
                Console.WriteLine($"{nameof(shape.ToString)} => {shape}");
            }
        }
    }
}