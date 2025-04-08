using SplashKitSDK;

public class MyLine : Shape
{
    private float _endX, _endY;

    public MyLine() : this(Color.Red, 0, 0, 100, 100) { }

    public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
    {
        X = startX;
        Y = startY;
        _endX = endX;
        _endY = endY;
    }

    public float EndX { get => _endX; set => _endX = value; }
    public float EndY { get => _endY; set => _endY = value; }

    public override void Draw()
    {
        SplashKit.DrawLine(Color, X, Y, EndX, EndY);
    }

    public override void DrawOutline()
    {
        SplashKit.FillCircle(Color.Black, X, Y, 3);
        SplashKit.FillCircle(Color.Black, EndX, EndY, 3);
    }

    public override bool IsAt(Point2D pt)
    {
        return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
    }
}
