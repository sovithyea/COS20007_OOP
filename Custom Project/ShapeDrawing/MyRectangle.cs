// MyRectangle.cs
using System.IO;
using SplashKitSDK;
using MyGame;

public class MyRectangle : Shape
{
    private int _width, _height;

    public MyRectangle() 
        : this(Color.Green, 0, 0, 200, 80) { }

    public MyRectangle(Color color, float x, float y, int width, int height)
        : base(color)
    {
        X = x; Y = y;
        _width  = width;
        _height = height;
    }

    public int Width  { get => _width;  set => _width  = value; }
    public int Height { get => _height; set => _height = value; }

    public override void Draw() =>
        SplashKit.FillRectangle(Color, X, Y, Width, Height);

    public override void DrawOutline() =>
        SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);

    public override bool IsAt(Point2D pt) =>
        pt.X >= X && pt.X <= X + Width &&
        pt.Y >= Y && pt.Y <= Y + Height;

    public override void SaveTo(StreamWriter writer)
    {
        writer.WriteLine("Rectangle");
        base.SaveTo(writer);
        writer.WriteLine(Width);
        writer.WriteLine(Height);
    }

    public override void LoadFrom(StreamReader reader)
    {
        base.LoadFrom(reader);
        Width  = reader.ReadInteger();
        Height = reader.ReadInteger();
    }
}
