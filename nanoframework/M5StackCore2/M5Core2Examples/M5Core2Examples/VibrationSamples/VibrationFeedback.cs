using System.Threading;
using nanoFramework.M5Core2;
using nanoFramework.M5Stack;

namespace M5Core2Examples.VibrationSamples
{
    public static class VibrationFeedback
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Click the middle button");

            M5Core2.TouchEvent += (sender, args) =>
            {
                if ((args.TouchEventCategory & TouchEventCategory.MiddleButton) == TouchEventCategory.MiddleButton)
                {
                    M5Core2.Vibrate = true;
                    Thread.Sleep(300);
                    M5Core2.Vibrate = false;
                }
            };
        }
    }
}
