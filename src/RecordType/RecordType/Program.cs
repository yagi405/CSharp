﻿using System;

namespace RecordType
{
    //public class Point2D
    //{
    //    public int X { get; }
    //    public int Y { get; }
    //    public Point2D(int x, int y) => (X, Y) = (x, y);

    //    //X座標とY座標の値で等価比較をするようにオーバーライド
    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null || obj.GetType() != GetType()) return false;
    //        var p = (Point2D)obj;
    //        return ReferenceEquals(this, p) ||
    //               X == p.X && Y == p.Y;
    //    }

    //    //X座標とY座標の値からハッシュ値を生成するようにオーバーライド
    //    public override int GetHashCode() => HashCode.Combine(X, Y);
    //}

    public record Point2D(int X, int Y);
    //{
    //    public int Property { get; }

    //    public Point2D(int x, int y, int property)
    //        : this(x, y)
    //    {
    //        Property = property;
    //    }

    //    public void Method()
    //    {
    //        Console.WriteLine("foo");
    //    }
    //}

    public class Program
    {
        private static void Main(string[] args)
        {
            var src = new Point2D(10, 20);

            var p1 = new Point2D(5, 10);
            var p2 = new Point2D(10, 20);

            //Point2D のインスタンス src が 他のインスタンス p1,p2 と
            //内容（X座標とY座標の値）が等しいかを判定したい
            Console.WriteLine($"a.Equals(p1)：{src.Equals(p1)}"); // False
            Console.WriteLine($"a.Equals(p2)：{src.Equals(p2)}"); // True

            //ToStringもオーバーライドされている
            Console.WriteLine(src); //Point2D { X = 10, Y = 20 }

            var copy = src with { X = 30, Y = 60 };
            Console.WriteLine(copy);
            Console.WriteLine(src);
        }
    }
}
