using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using M5Core2Examples.NetworkSamples;
using nanoFramework.M5Stack;
using nanoFramework.WebServer;

namespace M5Core2Examples.ServerSamples
{
    public static class M5WebServer
    {
        public static void Run()
        {
            // connect to Wifi
            if (!Wifi.Reconnect())
                return;

            Console.WriteLine(IPGlobalProperties.GetIPAddress().ToString());

            using var server = new WebServer(80, HttpProtocol.Http, new[] { typeof(TestController) });

            server.Start();

            Thread.Sleep(Timeout.Infinite);
        }
    }

   
    public class TestController
    {
        [Route("power")]
        [Method("GET")]
        public void RouteDevice(WebServerEventArgs e)
        {
            var power = M5Core2.Power;
           
            var sb = new StringBuilder();
            sb.AppendLine("Power:");
            sb.AppendLine($"  Adc Frequency: {power.AdcFrequency}");
            sb.AppendLine($"  Adc Pin Current: {power.AdcPinCurrent}");
            sb.AppendLine($"  Adc Pin Current Setting: {power.AdcPinCurrentSetting}");
            sb.AppendLine($"  Adc Pin Enabled: {power.AdcPinEnabled}");
            sb.AppendLine($"  Batt. Temp. Monitor: {power.BatteryTemperatureMonitoring}");
            sb.AppendLine($"  Charging Current: {power.ChargingCurrent}");
            sb.AppendLine($"  Charging Stop Threshold: {power.ChargingStopThreshold}");
            sb.AppendLine($"  Charging Voltage: {power.ChargingVoltage}");
            sb.AppendLine($"  Dc Dc1 Voltage: {power.DcDc1Voltage.Millivolts} mV");
            sb.AppendLine($"  Dc Dc2 Voltage: {power.DcDc2Voltage.Millivolts} mV");
            sb.AppendLine($"  Dc Dc3 Voltage: {power.DcDc3Voltage.Millivolts} mV");
            sb.AppendLine($"  EXTEN Enable: {power.EXTENEnable}");
            sb.AppendLine($"  VOff Voltage: {power.VoffVoltage}");
            sb.AppendLine($"  Gpio0 Behavior: {power.Gpio0Behavior}");
            sb.AppendLine($"  Gpio0 Value: {power.Gpio0Value}");

            e.Context.Response.ContentType = "text/plain";
            WebServer.OutPutStream(e.Context.Response, sb.ToString());
        }
    }
}
