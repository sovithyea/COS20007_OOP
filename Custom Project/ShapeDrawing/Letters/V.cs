using System.Collections.Generic;
using SplashKitSDK;
using MyGame;

public class V
{
    private List<Shape> _shapes = new List<Shape>();

    public V(float x, float y)
    {
        int width = 10;
        int height = 30;

        // Top outer bars
        _shapes.Add(new MyRectangle(Color.Black, x + 10, y + 5, width, height));            // left
        _shapes.Add(new MyRectangle(Color.Black, x + 50, y + 5, width, height));       // right

        // Middle diagonal
        _shapes.Add(new MyRectangle(Color.Black, x + 20, y + 30, width, height));  // left mid
        _shapes.Add(new MyRectangle(Color.Black, x + 40, y + 30, width, height));  // right mid

        // Bottom center
        _shapes.Add(new MyRectangle(Color.Black, x + 30, y + 60, width, height - 10));  // tip
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
