using System.Collections.Generic;
using SplashKitSDK;

public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;

    public Drawing(Color background)
    {
        _shapes = new List<Shape>();
        _background = background;
    }

    public Drawing() : this(Color.White) { }

    public List<Shape> SelectedShapes
    {
        get
        {
            List<Shape> selected = new List<Shape>();
            foreach (Shape s in _shapes)
            {
                if (s.Selected) selected.Add(s);
            }
            return selected;
        }
    }

    public int ShapeCount => _shapes.Count;

    public Color Background
    {
        get => _background;
        set => _background = value;
    }

    public void AddShape(Shape shape) => _shapes.Add(shape);

    public void RemoveShape(Shape shape) => _shapes.Remove(shape);

    public void RemoveLastShape()
    {
        if (_shapes.Count > 0)
            _shapes.RemoveAt(_shapes.Count - 1);
    }

    public void DeleteSelected()
    {
        _shapes.RemoveAll(s => s.Selected);
    }

    public void SelectShapesAt(Point2D pt)
    {
        foreach (Shape s in _shapes)
        {
            s.Selected = s.IsAt(pt);
        }
    }

    public void Draw()
    {
        SplashKit.ClearScreen(_background);
        foreach (Shape s in _shapes)
        {
            s.Draw();
            if (s.Selected) s.DrawOutline();
        }
        SplashKit.RefreshScreen();
    }
}
