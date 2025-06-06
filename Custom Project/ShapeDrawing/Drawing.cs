using System;
using System.Collections.Generic;
using SplashKitSDK;
using System.IO;

namespace MyGame
{
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

        public int ShapeCount
        {
            get => _shapes.Count;
        }

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

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteColor(Background);
                writer.WriteLine(ShapeCount);
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
        }

        public void Load(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                Background = reader.ReadColor();
                int count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    string? kind = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(kind)) continue;

                    Shape s;

                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            continue;
                    }

                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
        }
    }
}
