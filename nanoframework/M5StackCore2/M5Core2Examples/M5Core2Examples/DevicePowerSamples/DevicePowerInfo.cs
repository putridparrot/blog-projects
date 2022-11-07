using System.Threading;
using nanoFramework.M5Stack;

namespace M5Core2Examples.DevicePowerSamples
{
    public static class DevicePowerSample
    {
        public static void Run()
        {
            var power = M5Core2.Power;

            while (true)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 1;

                Console.WriteLine("Power:");
                Console.WriteLine($"  Adc Frequency: {power.AdcFrequency}");
                Console.WriteLine($"  Adc Pin Current: {power.AdcPinCurrent}");
                Console.WriteLine($"  Adc Pin Current Setting: {power.AdcPinCurrentSetting}");
                Console.WriteLine($"  Adc Pin Enabled: {power.AdcPinEnabled}");
                Console.WriteLine($"  Batt. Temp. Monitor: {power.BatteryTemperatureMonitoring}");
                Console.WriteLine($"  Charging Current: {power.ChargingCurrent}");
                Console.WriteLine($"  Charging Stop Threshold: {power.ChargingStopThreshold}");
                Console.WriteLine($"  Charging Voltage: {power.ChargingVoltage}");
                Console.WriteLine($"  Dc Dc1 Voltage: {power.DcDc1Voltage}");
                Console.WriteLine($"  Dc Dc2 Voltage: {power.DcDc2Voltage}");
                Console.WriteLine($"  Dc Dc3 Voltage: {power.DcDc3Voltage}");
                Console.WriteLine($"  EXTEN Enable: {power.EXTENEnable}");
                Console.WriteLine($"  VOff Voltage: {power.VoffVoltage}");
                Console.WriteLine($"  Gpio0 Behavior: {power.Gpio0Behavior}");
                Console.WriteLine($"  Gpio0 Value: {power.Gpio0Value}");

                Thread.Sleep(300);
            }
        }
    }
}
