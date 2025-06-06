using System.Collections.Generic;
using SplashKitSDK;
using MyGame;

public class T
{
    private List<Shape> _shapes = new List<Shape>();

    public T(float x, float y)
    {
        _shapes.Add(new MyRectangle(Color.Black, x, y, 50, 10));
        _shapes.Add(new MyRectangle(Color.Black, x + 20, y, 10, 80));
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
