using nanoFramework.M5Core2;
using nanoFramework.M5Stack;

namespace M5Core2Examples.TouchSamples
{
    public static class TouchCapabilities
    {
        public static void Run()
        {
            M5Core2.Vibrate = false;

            Console.Clear();
            Console.WriteLine("Click on the screen");

            M5Core2.TouchEvent += TouchEvent;
        }

        private static void TouchEvent(object sender, TouchEventArgs e)
        {
            Console.Clear();

            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            Console.WriteLine($"({e.X},{e.Y}) {e.Id}");

            if ((e.TouchEventCategory & TouchEventCategory.LeftButton) == TouchEventCategory.LeftButton)
            {
                Console.WriteLine("Left Button Pressed");
            }
            else if ((e.TouchEventCategory & TouchEventCategory.MiddleButton) == TouchEventCategory.MiddleButton)
            {
                Console.WriteLine("Middle Button Pressed");
            }
            else if ((e.TouchEventCategory & TouchEventCategory.RightButton) == TouchEventCategory.RightButton)
            {
                Console.WriteLine("Right Button Pressed");
            }

            if ((e.TouchEventCategory & TouchEventCategory.Moving) == TouchEventCategory.Moving)
            {
                Console.WriteLine("Moving");
            }

            if ((e.TouchEventCategory & TouchEventCategory.LiftUp) == TouchEventCategory.LiftUp)
            {
                Console.WriteLine("Lift Up");
            }

            if ((e.TouchEventCategory & TouchEventCategory.DoubleTouch) == TouchEventCategory.DoubleTouch)
            {
                // Note: the M5Core2 does not support this event.
                Console.WriteLine("Double Touch");
            }
        }
    }
}
