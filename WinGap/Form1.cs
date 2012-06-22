using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebKit;
using WebKit.DOM;
using WebKit.Interop;
using WebKit.JSCore;

namespace WinGap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = new Uri(Environment.CurrentDirectory.Replace('\\', '/') + "/www/", UriKind.Absolute).AbsoluteUri;
            webKitBrowser1.Navigate(url);
        }

        private void webKitBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            JSObject wg;
            wg = webKitBrowser1.GetScriptManager.GlobalContext.GetGlobalObject();
            wg.SetProperty("wingap", new wingap());
        }
    }
}
