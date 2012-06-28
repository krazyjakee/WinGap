using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WebKit;
using WebKit.DOM;
using WebKit.Interop;
#if DOTNET4
using WebKit.JSCore;
#endif
namespace WinGap
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = new Uri(Environment.CurrentDirectory.Replace('\\', '/') + "/www/index.html", UriKind.Absolute).AbsoluteUri;
            webKitBrowser1.Navigate(url);
        }

        private void webKitBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            WebKit.JSCore.JSObject wg;
            wg = webKitBrowser1.GetScriptManager.GlobalContext.GetGlobalObject();
            wg.SetProperty("wingap", new wingap());
            wg.SetProperty("form", this);
        }

        public void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void setup(int width, int height, string title, string bordertype, bool transparent, string transparencykey)
        {
            if (transparent)
            {
                webKitBrowser1.WebView.setTransparent(1);
                if (transparencykey.Length > 0)
                {
                    Color col = ColorTranslator.FromHtml("#" + transparencykey);
                    this.TransparencyKey = col;
                    this.BackColor = col;
                }
            }

            switch (bordertype)
            {
                case "Fixed3D": this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D; break;
                case "FixedDialog": this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; break;
                case "FixedSingle": this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; break;
                case "FixedToolWindow": this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow; break;
                case "None": this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; break;
                case "Sizable": this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable; break;
                case "SizableToolWindow": this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow; break;
            }

            this.Text = title;
            this.Width = width;
            this.Height = height;
        }
        public void setDragBar(int x, int y, int width, int height, string bgcolor, string bgimage, bool repeat)
        {
            panel1.Visible = true;
            panel1.Left = x;
            panel1.Top = y;
            panel1.Width = width;
            panel1.Height = height;
            if (bgcolor.Length > 0)
            {
                panel1.BackColor = ColorTranslator.FromHtml("#" + bgcolor);
            }
            if (bgimage.Length > 0)
            {
                string url = new Uri(Environment.CurrentDirectory.Replace('\\', '/') + "/www/" + bgimage, UriKind.Absolute).AbsoluteUri;
                panel1.BackgroundImage = Image.FromFile(url.ToString());
            }

            if (repeat)
            {
                panel1.BackgroundImageLayout = ImageLayout.Tile;
            }
            else
            {
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void webKitBrowser1_Load(object sender, EventArgs e)
        {

        }

    }
}
