using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Openfin.Desktop;
using Window = System.Windows.Window;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var runtime = Runtime.GetRuntimeInstance(new RuntimeOptions {Version = "9.61.38.40" });
            runtime.Connect(() =>
            {
                //runtime.InterApplicationBus.subscribe("my-topic", (uuid, topic, message) =>
                //{
                //    if (message != null)
                //    {
                //        Debug.WriteLine(message.ToString());
                //    }
                //});

                // alternative
                InterApplicationBus.Subscription<string>(runtime, "my-topic").MessageReceived += (sender, msg) =>
                {
                    if (msg != null)
                    {
                        Debug.WriteLine(msg.Message);
                    }
                };

            });
        }

    }
}
