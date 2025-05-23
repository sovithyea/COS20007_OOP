using SplashKitSDK;

public abstract class Shape
{
    private Color _color;
    private float _x, _y;
    private bool _selected;
    public Shape() : this(Color.Yellow) {}
    public Shape(Color color)
    {
        _color = color;
        _x = 0;
        _y = 0;
    }
    public float X { get => _x; set => _x = value; }
    public float Y { get => _y; set => _y = value; }
    public Color Color { get => _color; set => _color = value; }
    public bool Selected { get => _selected; set => _selected = value; }
    public abstract void Draw();
    public abstract void DrawOutline();
    public abstract bool IsAt(Point2D pt);
}
