namespace Inheritance
{
    public record Point3D(int X, int Y, int Z) : Point2D(X, Y);
    //public class Point3D : Point2D
    //{
    //    public int Z { get; }

    //    public Point3D(int x, int y, int z) : base(x, y)
    //    {
    //        Z = z;
    //    }
    //}
}
