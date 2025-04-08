using SplashKitSDK;
using System;

public class Program
{
    private enum ShapeKind
    {
        Rectangle,
        Circle,
        Line
    }

    public static void Main()
    {
        Window window = new Window("Shape Drawer", 800, 600);
        Drawing drawing = new Drawing();
        ShapeKind kindToAdd = ShapeKind.Circle;

        do
        {
            SplashKit.ProcessEvents();

            if (SplashKit.KeyTyped(KeyCode.RKey)) kindToAdd = ShapeKind.Rectangle;
            if (SplashKit.KeyTyped(KeyCode.CKey)) kindToAdd = ShapeKind.Circle;
            if (SplashKit.KeyTyped(KeyCode.LKey)) kindToAdd = ShapeKind.Line;

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Shape newShape;
                float x = SplashKit.MouseX();
                float y = SplashKit.MouseY();

                switch (kindToAdd)
                {
                    case ShapeKind.Rectangle:
                        newShape = new MyRectangle(Color.Green, x, y, 100, 100);
                        break;
                    case ShapeKind.Circle:
                        newShape = new MyCircle(Color.Blue, x, y, 50);
                        break;
                    case ShapeKind.Line:
                        newShape = new MyLine(Color.Red, x, y, x + 100, y + 50);
                        break;
                    default:
                        newShape = new MyRectangle();
                        break;
                }

                drawing.AddShape(newShape);
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                drawing.SelectShapesAt(SplashKit.MousePosition());
            }

            if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                drawing.DeleteSelected();
            }
            if (SplashKit.KeyTyped(KeyCode.DeleteKey))
            {
                drawing.RemoveLastShape();
            }

            drawing.Draw();

        } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
    }
}
