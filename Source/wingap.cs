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

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey); // Keys enumeration

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        public string activeKeys = string.Empty;

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

        public void keyListener()
        {
            Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 50;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            activeKeys = "";
            foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
            {
                int x = GetAsyncKeyState(i);
                if ((x == 1) || (x == Int16.MinValue))
                {
                    activeKeys += Enum.GetName(typeof(Keys), i) + " ";
                }
            }
        }
    }
}
