using System.Collections.Generic;
using SplashKitSDK;
using MyGame;

public class H
{
    private List<Shape> _shapes = new List<Shape>();

    public H(float x, float y)
    {
        _shapes.Add(new MyRectangle(Color.Black, x, y, 10, 80));
        _shapes.Add(new MyRectangle(Color.Black, x + 40, y, 10, 80));
        _shapes.Add(new MyRectangle(Color.Black, x, y + 35, 50, 10));
    }

    public void Draw()
    {
        foreach (Shape s in _shapes) s.Draw();
    }

    public void Scale(float factor)
    {
        foreach (Shape s in _shapes)
        {
            if (s is MyRectangle r)
            {
                r.Width = (int)(r.Width * factor);
                r.Height = (int)(r.Height * factor);
            }
        }
    }
    public List<Shape> Shapes => _shapes;
}
