using System;
using SplashKitSDK;
using MyGame;
using System.Collections.Generic;

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

            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                Random rnd = new Random();
                int count = rnd.Next(5, 11);

                for (int i = 0; i < count; i++)
                {
                    float x = rnd.Next(0, 700);
                    float y = rnd.Next(0, 500);
                    Color color = SplashKit.RGBColor(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    Shape shape;

                    int shapeType = rnd.Next(3);
                    switch (shapeType)
                    {
                        case 0:
                            shape = new MyRectangle(color, x, y, 100, 60);
                            break;
                        case 1:
                            shape = new MyCircle(color, x, y, 40);
                            break;
                        default:
                            shape = new MyLine(color, x, y, x + 80, y + 20);
                            break;
                    }

                    drawing.AddShape(shape);
                }
            }

            if (SplashKit.KeyTyped(KeyCode.NKey))
            {
                float startX = 50;
                float startY = 100;
                float spacing = 80;

                V v = new V(startX, startY);
                I i = new I(startX + spacing, startY);
                T t = new T(startX + spacing * 2, startY);
                H h = new H(startX + spacing * 3, startY);

                foreach (Shape s in v.Shapes) drawing.AddShape(s);
                foreach (Shape s in i.Shapes) drawing.AddShape(s);
                foreach (Shape s in t.Shapes) drawing.AddShape(s);
                foreach (Shape s in h.Shapes) drawing.AddShape(s);
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                drawing.SelectShapesAt(SplashKit.MousePosition());
            }

            if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                drawing.DeleteSelected();
            }

            if (SplashKit.KeyTyped(KeyCode.FKey))
            {
                foreach (Shape s in drawing.SelectedShapes)
                {
                    if (s is MyRectangle r)
                    {
                        r.Width += 10;
                        r.Height += 10;
                    }
                    else if (s is MyCircle c)
                    {
                        c.Radius += 5;
                    }
                    else if (s is MyLine l)
                    {
                        float dx = (l.EndX - l.X) * 1.2f;
                        float dy = (l.EndY - l.Y) * 1.2f;
                        l.EndX = l.X + dx;
                        l.EndY = l.Y + dy;
                    }
                }
            }

            if (SplashKit.KeyTyped(KeyCode.DKey))
            {
                foreach (Shape s in drawing.SelectedShapes)
                {
                    if (s is MyRectangle r)
                    {
                        r.Width = Math.Max(10, r.Width - 10);
                        r.Height = Math.Max(10, r.Height - 10);
                    }
                    else if (s is MyCircle c)
                    {
                        c.Radius = Math.Max(5, c.Radius - 5);
                    }
                    else if (s is MyLine l)
                    {
                        float dx = (l.EndX - l.X) * 0.8f;
                        float dy = (l.EndY - l.Y) * 0.8f;
                        l.EndX = l.X + dx;
                        l.EndY = l.Y + dy;
                    }
                }
            }

            if (SplashKit.KeyTyped(KeyCode.SKey))
            {
                drawing.Save("/Users/macbook/Library/CloudStorage/OneDrive-SwinburneUniversity/University/2025_semester1/COS20007_OOP/Custom Project/ShapeDrawing/105270743.txt");
            }

            if (SplashKit.KeyTyped(KeyCode.AKey))
            {
                drawing.Load("/Users/macbook/Library/CloudStorage/OneDrive-SwinburneUniversity/University/2025_semester1/COS20007_OOP/Custom Project/ShapeDrawing/105270743.txt");
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
