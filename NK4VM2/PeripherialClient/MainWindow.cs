using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeripherialClient
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            OutputBox.Text += "Connecting to " + IPBox.Text + ":" + PortBox.Text + "\r\n";
            IPHostEntry ipHostInfo = Dns.Resolve(IPBox.Text);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(ipAddress, Int32.Parse(PortBox.Text));
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            byte[] buf = new byte[256];
            try
            {
                String str = "Peripheral:" + OffsetBox.Text + ":" + NameBox.Text;
                s.Connect(ipe);
                s.ReceiveTimeout = 5000;
                OutputBox.Text += "Connected\r\n";
                s.Send(System.Text.Encoding.UTF8.GetBytes(str));
                OutputBox.Text += "Sent " + str + "\r\n";
                try
                {
                    s.Receive(buf);
                }
                catch (Exception ex)
                {
                    OutputBox.Text += ex.ToString() + "\r\n";
                }
                str = System.Text.Encoding.UTF8.GetString(buf);
                OutputBox.Text += "Got " + str + "\r\n";
                s.Close();
                OutputBox.Text += "Closed connection" + "\r\n";
            }
            catch (ArgumentNullException ae)
            {
                OutputBox.Text += "ArgumentNullException : " + ae.ToString();
            }
            catch (SocketException se)
            {
                OutputBox.Text += "SocketException : " + se.ToString();
            }
            catch (Exception ue)
            {
                OutputBox.Text += "Unexpected exception : " + ue.ToString();
            }
        }
    }
}
