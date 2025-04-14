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
        Console.Write("Enter your name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty. Defaulting to 'Unknown'.");
            name = "Unknown"; 
        }
        int numberOfLines = GetCountFromInput(name);

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
                float x = SplashKit.MouseX();
                float y = SplashKit.MouseY();

                if (kindToAdd == ShapeKind.Line)
                {
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        float offsetY = i * 5; 
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

            if (SplashKit.KeyTyped(KeyCode.SKey))
            {
                drawing.Save("/Users/macbook/Library/CloudStorage/OneDrive-SwinburneUniversity/2025_Semester1/Object Oriented Programming-COS20007/COS20007_OOP/week7/task7.1/ShapeDrawing/TestDrawing.txt");
            }

            if (SplashKit.KeyTyped(KeyCode.OKey))
            {
                drawing.Load("/Users/macbook/Library/CloudStorage/OneDrive-SwinburneUniversity/2025_Semester1/Object Oriented Programming-COS20007/COS20007_OOP/week7/task7.1/ShapeDrawing/TestDrawing.txt");
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
    public static int GetCountFromInput(string name)
    {
        int NameCount = name.Length;
        return NameCount;
    }  

}
