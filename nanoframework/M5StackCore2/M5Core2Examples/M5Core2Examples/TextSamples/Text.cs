using nanoFramework.M5Stack;
using nanoFramework.Presentation.Media;

namespace M5Core2Examples.TextSamples
{
    public static class Text
    {
        public static void Run()
        {
            // clear the console
            Console.Clear();

            // output some test
            Console.WriteLine("Some Text");

            // change the foreground colour
            Console.ForegroundColor = Color.Red;
            Console.WriteLine("Some Red Text");

            // change foreground and background colours
            Console.BackgroundColor = Color.Yellow;
            Console.ForegroundColor = Color.Blue;
            Console.WriteLine("Some Green Text on Yellow Background");

            // get the font size
            Console.ResetColor();
            Console.WriteLine($"Current font height {Console.Font.Height}");

            Console.CursorLeft = 3;
            Console.CursorTop = 5;
            Console.WriteLine("Moved Cursor");

            Console.WriteLine($"Height: {Console.WindowHeight}, Width: {Console.WindowWidth}");
        }
    }
}
