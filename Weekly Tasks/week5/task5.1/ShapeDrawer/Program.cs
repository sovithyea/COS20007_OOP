using SplashKitSDK;
using ShapeDrawing;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Window window = new Window("Shape Drawer 5.1", 800, 600);
        Drawing myDrawing = new Drawing();

        do
        {
            SplashKit.ProcessEvents();

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Shape shape = new Shape(50, 'Z'); 
                shape.X = SplashKit.MouseX();
                shape.Y = SplashKit.MouseY();
                myDrawing.AddShape(shape);
            }

            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                myDrawing.Background = SplashKit.RandomRGBColor(255);
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                Point2D point = new Point2D()
                {
                    X = SplashKit.MouseX(),
                    Y = SplashKit.MouseY()
                };
                myDrawing.SelectShapesAt(point);
            }

            if (SplashKit.KeyTyped(KeyCode.DeleteKey))
            {
                foreach (Shape shape in myDrawing.SelectedShapes)
                {
                    myDrawing.RemoveShape(shape);
                }
            }
            if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                myDrawing.RemoveLastShape();
            }
            
            SplashKit.ClearScreen(Color.White);
            myDrawing.Draw(); 
            SplashKit.RefreshScreen();

        } while (!SplashKit.QuitRequested());
    }
}