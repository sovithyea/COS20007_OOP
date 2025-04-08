using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;

        public Shape(int param, char firstChar)
        {
            if (firstChar >= 'A' && firstChar <= 'K')
            {
                _color = Color.Azure;
            }
            else
            {
                _color = Color.Chocolate;
            }

            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public bool IsAt(Point2D pt)
        {
            return pt.X >= _x && pt.X <= _x + _width &&
                   pt.Y >= _y && pt.Y <= _y + _height;
        }
          public void DrawOutline()
        {
            const int offset = 8; // 5 + 3
            SplashKit.DrawRectangle(Color.Black, _x - offset, _y - offset, _width + 2 * offset, _height + 2 * offset);
        }

        public void Draw()
        {
            if (_selected) DrawOutline();
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }
    }
}
