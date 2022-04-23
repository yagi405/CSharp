namespace Inheritance
{
    public record Point2D(int X, int Y);

    //public class Point2D
    //{
    //    public int X { get; }
    //    public int Y { get; }

    //    public Point2D(int x, int y)
    //    {
    //        X = x;
    //        Y = y;
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null || GetType() != obj.GetType())
    //        {
    //            return false;
    //        }

    //        var p = (Point2D)obj;
    //        return this == p ||
    //               X == p.X && Y == p.Y;
    //    }

    //    public override int GetHashCode()
    //    {
    //        //return X.GetHashCode() * 397 ^ Y.GetHashCode();
    //        return HashCode.Combine(X.GetHashCode(), Y.GetHashCode());
    //    }

    //    public override string ToString()
    //    {
    //        return $"Point2D {{ X = {X}, Y = {Y} }}";
    //    }
    //}
}
