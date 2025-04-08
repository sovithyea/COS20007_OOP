using System;
namespace ShapeDrawing;
class Program
{
    static void Main(string[] args)
    {
        Shape myShape = new Shape(143);
        myShape.Draw();
        Console.WriteLine("The diagonal lenght of the shape is: " + myShape.ComputeDiagonal());
    }
}