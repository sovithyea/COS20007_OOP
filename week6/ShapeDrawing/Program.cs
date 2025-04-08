using System;
using SplashKitSDK;

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

        int numberOfLines = 9;

        do
        {
            SplashKit.ProcessEvents();

            if (SplashKit.KeyTyped(KeyCode.RKey)) kindToAdd = ShapeKind.Rectangle;
            if (SplashKit.KeyTyped(KeyCode.CKey)) kindToAdd = ShapeKind.Circle;
            if (SplashKit.KeyTyped(KeyCode.LKey)) kindToAdd = ShapeKind.Line;

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                float x = SplashKit.MouseX();
                float y = SplashKit.MouseY();

                if (kindToAdd == ShapeKind.Line)
                {
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        float offsetY = i * 10; 
                        Shape line = new MyLine(Color.Red, x, y + offsetY, x + 100, y + offsetY);
                        drawing.AddShape(line);
                    }
                }
                else
                {
                    Shape newShape;

                    switch (kindToAdd)
                    {
                        case ShapeKind.Rectangle:
                            newShape = new MyRectangle(Color.Green, x, y, 100, 100);
                            break;
                        case ShapeKind.Circle:
                            newShape = new MyCircle(Color.Blue, x, y, 50);
                            break;
                        default:
                            newShape = new MyRectangle();
                            break;
                    }

                    drawing.AddShape(newShape);
                }
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                drawing.SelectShapesAt(SplashKit.MousePosition());
            }

            if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                drawing.DeleteSelected();
            }

            drawing.Draw();

        } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
    }
}
