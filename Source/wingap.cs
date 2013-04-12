using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinGap
{
    class wingap
    {
        public string helloWorld()
        {
            return "Hello World!";
        }

        public void quit()
        {
            Environment.Exit(0);
        }

        public void open(string address, string args = "")
        {
            if (address.StartsWith("http"))
            {
                var startInfo = new ProcessStartInfo("explorer.exe", address);
                Process.Start(startInfo);
            }
            else
            {
                Process.Start(@"" + address, args);
            }
        }
    }
}
