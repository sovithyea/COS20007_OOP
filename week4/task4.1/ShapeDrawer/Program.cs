using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the first letter of your name: ");
            string input = Console.ReadLine();

            char firstChar;
            if (!string.IsNullOrEmpty(input))
            {
                firstChar = char.ToUpper(input[0]);
            }
            else
            {
                Console.WriteLine("Invalid input - Defaulting to 'A' ");
                firstChar = 'A';
            }

                Shape myShape = new Shape(143, firstChar);
                Window window = new Window("Shape Drawer", 800, 600);

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);
                Point2D clickPoint = SplashKit.MousePosition();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myShape.Color = SplashKit.RandomColor();
                }
                if (myShape.IsWithinCircleRadius(clickPoint))
                {
                    Console.WriteLine("Mouse is within circle radius");
                }
                else
                {
                    Console.WriteLine("Mouse is not within circle radius");
                }
                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    break;
                }
                myShape.Draw();
                SplashKit.RefreshScreen();
            }
            window.Close();
        }
    }
}
