using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window window = new Window("Test Window", 800, 600);
        while (!SplashKit.QuitRequested())
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.White);
            SplashKit.RefreshScreen();
        }
    }
}