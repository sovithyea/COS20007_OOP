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

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            return pt.X >= _x && pt.X <= _x + _width &&
                   pt.Y >= _y && pt.Y <= _y + _height;
        }
        public bool IsWithinCircleRadius(Point2D pt, double radius = 50)
        {
            double centerX = _x + _width / 2;
            double centerY = _y + _height / 2;
            double distance = Math.Sqrt(Math.Pow(centerX - pt.X, 2) + Math.Pow(centerY - pt.Y, 2));
            return distance <= radius;
        }
    }
}
