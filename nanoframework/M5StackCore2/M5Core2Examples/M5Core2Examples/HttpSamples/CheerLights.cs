using System;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using M5Core2Examples.NetworkSamples;
using nanoFramework.M5Stack;
using nanoFramework.Presentation.Media;

namespace M5Core2Examples.HttpSamples
{
    public static class CheerLights
    {
        private static readonly HttpClient HttpClient = new();

        public static void Run()
        {
            // connect to Wifi
            if(!Wifi.Run())
                return;

            while (true)
            {
                try
                {
                    HttpClient.HttpsAuthentCert = new X509Certificate(
                        @"-----BEGIN CERTIFICATE-----
MIIDrzCCApegAwIBAgIQCDvgVpBCRrGhdWrJWZHHSjANBgkqhkiG9w0BAQUFADBh
MQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3
d3cuZGlnaWNlcnQuY29tMSAwHgYDVQQDExdEaWdpQ2VydCBHbG9iYWwgUm9vdCBD
QTAeFw0wNjExMTAwMDAwMDBaFw0zMTExMTAwMDAwMDBaMGExCzAJBgNVBAYTAlVT
MRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdpY2VydC5j
b20xIDAeBgNVBAMTF0RpZ2lDZXJ0IEdsb2JhbCBSb290IENBMIIBIjANBgkqhkiG
9w0BAQEFAAOCAQ8AMIIBCgKCAQEA4jvhEXLeqKTTo1eqUKKPC3eQyaKl7hLOllsB
CSDMAZOnTjC3U/dDxGkAV53ijSLdhwZAAIEJzs4bg7/fzTtxRuLWZscFs3YnFo97
nh6Vfe63SKMI2tavegw5BmV/Sl0fvBf4q77uKNd0f3p4mVmFaG5cIzJLv07A6Fpt
43C/dxC//AH2hdmoRBBYMql1GNXRor5H4idq9Joz+EkIYIvUX7Q6hL+hqkpMfT7P
T19sdl6gSzeRntwi5m3OFBqOasv+zbMUZBfHWymeMr/y7vrTC0LUq7dBMtoM1O/4
gdW7jVg/tRvoSSiicNoxBN33shbyTApOB6jtSj1etX+jkMOvJwIDAQABo2MwYTAO
BgNVHQ8BAf8EBAMCAYYwDwYDVR0TAQH/BAUwAwEB/zAdBgNVHQ4EFgQUA95QNVbR
TLtm8KPiGxvDl7I90VUwHwYDVR0jBBgwFoAUA95QNVbRTLtm8KPiGxvDl7I90VUw
DQYJKoZIhvcNAQEFBQADggEBAMucN6pIExIK+t1EnE9SsPTfrgT1eXkIoyQY/Esr
hMAtudXH/vTBH1jLuG2cenTnmCmrEbXjcKChzUyImZOMkXDiqw8cvpOp/2PV5Adg
06O/nVsJ8dWO41P0jmP6P6fbtGbfYmbW0W5BjfIttep3Sp+dWOIrWcBAI+0tKIJF
PnlUkiaY4IBIqDfv8NZ5YBberOgOzW6sRBc4L0na4UU+Krk2U886UAb3LujEV0ls
YSEY1QSteDwsOoBrp+uvFRTp2InBuThs4pFsiv9kuXclVzDAGySj4dzp30d8tbQk
CAUw7C29C79Fv1C5qfPrmAESrciIxpg0X40KPMbp1ZWVbd4=
-----END CERTIFICATE-----");

                    HttpClient.DefaultRequestHeaders.Add("x-ms-blob-type", "BlockBlob");

                    var requestUri = "https://api.thingspeak.com/channels/1417/field/2/last.txt";

                    var response = HttpClient.Get(requestUri);

                    response.EnsureSuccessStatusCode();
                    var responseBody = response.Content.ReadAsString();
                    if (responseBody != null && responseBody.StartsWith("#"))
                    {
                        responseBody = responseBody.Substring(1);

                        var r = Convert.ToByte(responseBody.Substring(0, 2), 16);
                        var g = Convert.ToByte(responseBody.Substring(2, 2), 16);
                        var b = Convert.ToByte(responseBody.Substring(4, 2), 16);
                        var colour = ColorUtility.ColorFromRGB(r, g, b);

                        Screen.Clear();
                        Screen.Write(0, 0, 320, 240, new[] { ColorUtility.To16Bpp(colour) });
                    }

                    Debug.WriteLine(responseBody);

                    Thread.Sleep(TimeSpan.FromMinutes(2));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
