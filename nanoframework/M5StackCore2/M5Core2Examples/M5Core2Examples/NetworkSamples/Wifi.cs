using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using nanoFramework.Networking;

namespace M5Core2Examples.NetworkSamples
{
    internal static partial class Wifi
    {
        public static bool Run()
        {
            var configuration = Wireless80211Configuration.GetAllWireless80211Configurations();
            foreach (var config in configuration)
            {
                Debug.WriteLine($"SSID: {config.Ssid}, Password: {config.Password}");
            }

            return Connect();
        }

        public static bool Connect()
        {
            var cs = new CancellationTokenSource(60000);
            var success = WifiNetworkHelper.ConnectDhcp(SSID, PASSWORD, requiresDateTime: true, token: cs.Token);
            if (!success)
            {
                Debug.WriteLine($"Can't connect to the network, error: {WifiNetworkHelper.Status}");
                if (WifiNetworkHelper.HelperException != null)
                {
                    Debug.WriteLine($"ex: {WifiNetworkHelper.HelperException}");
                }

                return false;
            }

            Debug.WriteLine("Connected successfully");
            return true;
        }

        public static bool Reconnect()
        {
            var cs = new CancellationTokenSource(60000);
            var success = WifiNetworkHelper.Reconnect(requiresDateTime: true, token: cs.Token);
            if (!success)
            {
                Debug.WriteLine($"Can't connect to the network, error: {WifiNetworkHelper.Status}");
                if (WifiNetworkHelper.HelperException != null)
                {
                    Debug.WriteLine($"ex: {WifiNetworkHelper.HelperException}");
                }

                return false;
            }
            Debug.WriteLine("Reconnected successfully");
            return true;
        }
    }
}
