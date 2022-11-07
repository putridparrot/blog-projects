using System.Threading;
using nanoFramework.M5Stack;
using Console = nanoFramework.M5Stack.Console;

namespace M5Core2Examples.LedSamples
{
    public static class Blinky
    {
        public static void Run()
        {
            var ledState = true;
            while (true)
            {
                Console.WriteLine($"Set Led {ledState}");
                // NOTE: This requires a version of M5Core2 with the fix for the Power Led
                // simply reverse the state for the current 2.1.1.82 version of the lib.
                M5Core2.PowerLed = ledState;
                ledState = !ledState;
                Thread.Sleep(3000);
            }
        }
    }
}
