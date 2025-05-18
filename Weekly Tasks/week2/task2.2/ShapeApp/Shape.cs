using System;
namespace ShapeDrawing
{
    public class Shape
    {
        private string _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
        public Shape(int param)
        {
            _color = "Blue"; 
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }
        public string Color
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
        public double ComputeDiagonal()
        {
            return Math.Sqrt(2) * _height;
        }
        public void Draw()
        {
            Console.WriteLine("Color is " + _color);
            Console.WriteLine("Position X is " + _x);
            Console.WriteLine("Position Y is " + _y);
            Console.WriteLine("Width is " + _width);
            Console.WriteLine("Height is " + _height);
        }
    }
}