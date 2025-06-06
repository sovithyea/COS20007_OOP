// MyCircle.cs
using System.IO;
using SplashKitSDK;
using MyGame;

public class MyCircle : Shape
{
    private int _radius;

    public MyCircle() 
        : this(Color.Blue, 0, 0, 50) { }

    public MyCircle(Color color, float x, float y, int radius)
        : base(color)
    {
        X = x; Y = y;
        _radius = radius;
    }

    public int Radius { get => _radius; set => _radius = value; }

    public override void Draw() =>
        SplashKit.FillCircle(Color, X, Y, Radius);

    public override void DrawOutline() =>
        SplashKit.DrawCircle(Color.Black, X, Y, Radius + 2);

    public override bool IsAt(Point2D pt) =>
        SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));

    public override void SaveTo(StreamWriter writer)
    {
        writer.WriteLine("Circle");
        base.SaveTo(writer);
        writer.WriteLine(Radius);
    }

    public override void LoadFrom(StreamReader reader)
    {
        base.LoadFrom(reader);
        Radius = reader.ReadInteger();
    }
}
