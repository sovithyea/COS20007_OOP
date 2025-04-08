using System.Collections.Generic;
using SplashKitSDK;
using ShapeDrawing;

public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;
    public Drawing(Color background)
    {
        _shapes = new List<Shape>();
        _background = background;
    }
    public Drawing() : this(Color.White)
    {}
    public List<Shape> SelectedShapes
    {
        get 
        { 
            List<Shape> selectedShapes = new List<Shape>();
            foreach (Shape shape in _shapes)
            {
                if (shape.Selected)
                {
                    selectedShapes.Add(shape);
                }
            }
            return selectedShapes; 
        }
    }
    public int ShapeCount
    {
        get { return _shapes.Count; }
    }
    public Color Background
    {
        get { return _background; }
        set { _background = value; }
    }
    public void Draw()
    {
        SplashKit.ClearScreen(_background);
        foreach (Shape shape in _shapes)
        {
            shape.Draw();
        }
        SplashKit.RefreshScreen();
    }
    
    public void SelectShapesAt(Point2D pt)
    {
        foreach (Shape s in _shapes)
        {
            s.Selected = s.IsAt(pt);
        }
    }
    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);
    }
    public void RemoveShape(Shape shape)
    {
        _shapes.Remove(shape);
    }
    public void RemoveLastShape()
    {
        if (_shapes.Count > 0)
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }
    }    
}