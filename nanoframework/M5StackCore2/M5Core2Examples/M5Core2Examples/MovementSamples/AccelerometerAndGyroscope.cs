using System.Threading;
using nanoFramework.M5Stack;

namespace M5Core2Examples.MovementSamples
{
    public static class AccelerometerAndGyroscope
    {
        public static void Run()
        {
            Console.Clear();

            M5Core2.AccelerometerGyroscope.Calibrate(100);

            while (true)
            {
                var accelerometer = M5Core2.AccelerometerGyroscope.GetAccelerometer();
                var gyroscope = M5Core2.AccelerometerGyroscope.GetGyroscope();
                var temperature = M5Core2.AccelerometerGyroscope.GetInternalTemperature();

                Console.CursorLeft = 0;
                Console.CursorTop = 1;

                Console.WriteLine("Accelerator:");
                Console.WriteLine($"  x={accelerometer.X}");
                Console.WriteLine($"  y={accelerometer.Y}");
                Console.WriteLine($"  z={accelerometer.Z}");
                Console.WriteLine("Gyroscope:");
                Console.WriteLine($"  x={gyroscope.X}");
                Console.WriteLine($"  y={gyroscope.Y}");
                Console.WriteLine($"  z={gyroscope.Z}");
                Console.WriteLine("Internal Temp:");
                Console.WriteLine($"  Celsius={temperature.DegreesCelsius}");

                Thread.Sleep(20);
            }
        }
    }
}
