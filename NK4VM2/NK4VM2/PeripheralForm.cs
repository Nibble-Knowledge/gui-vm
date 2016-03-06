using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NK4VM2
{
    public partial class PeripheralForm : Form
    {

        private byte[] buf = new byte[256];
        private UInt16[] memory;
        public List<Peripheral> Peripherals { get; set; }
        public int maxThreads { get; set; }

        public PeripheralForm(UInt16[] mem)
        {
            memory = mem;
            InitializeComponent();
            startListening();
        }

        private async void startListening()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 4444);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            maxThreads = 4;
            Peripherals = new List<Peripheral>(16);
            for (int i = 0; i < 16; i++)
            {
                PeripheralList.Items.Add("null");
                Peripherals.Add(null);
            }
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                while (true)
                {
                    var bw = new BackgroundWorker();
                    bw.DoWork += (o, args) => acceptCon(listener);
                    bw.RunWorkerCompleted += (o, args) => Done();
                    bw.RunWorkerAsync();
                    maxThreads--;
                    updatePerphs();
                    while (maxThreads <= 0)
                    {
                        updatePerphs();
                        await maxCheck();
                    }
                }
            }
            catch (Exception e)
            {
                PeripheralList.Items.Add(e.ToString());
            }

        }

        private void updatePerphs()
        {
            for (int i = 0; i < 16; i++ )
            {
                if (Peripherals[i] != null)
                {
                    bool part1 = Peripherals[i].socket.Poll(1000, SelectMode.SelectRead);
                    bool part2 = (Peripherals[i].socket.Available == 0);
                    bool part3 = Peripherals[i].socket.Connected;
                    if (part1 && part2 && part3)
                    {
                        if (PeripheralList.Items[i].ToString() != Peripherals[i].ToString())
                        {
                            PeripheralList.Items[i] = Peripherals[i].ToString();
                        }
                    }
                    else
                    {
                        Peripherals[i].socket.Close();
                        Peripherals[i] = null;
                        if (PeripheralList.Items[i].ToString() != "null")
                        {
                            PeripheralList.Items[i] = "null";
                        }
                    }
                }
                if (PeripheralList.Items[i].ToString() != "null")
                {
                    PeripheralList.Items[i] = "null";
                }
            }
        }

        private async Task maxCheck()
        {
            await Task.Delay(100);
        }

        private void Done()
        {
            maxThreads++;
        }

        private void acceptCon(Socket listener)
        {
            Socket handler = listener.Accept();
            handler.ReceiveTimeout = 5000;
            handler.SendTimeout = 5000;
            handler.Receive(buf);
            string[] split = System.Text.Encoding.UTF8.GetString(buf).Split(':');
            //Format for message is "Peripheral:<OFFSET>:<NAME>
            if (split.Length != 3 || split[0] != "Peripheral")
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                return;
            }
            int spot = int.Parse(split[1]);
            if (Peripherals.Count > spot)
            {
                if (Peripherals.ElementAtOrDefault(spot) != null)
                {
                    int i = 0;
                    spot = -1;
                    for (i = 0; i < Peripherals.Count; i++)
                    {
                        if (Peripherals.ElementAtOrDefault(i) == null)
                        {
                            spot = i;
                            break;
                        }
                    }
                    if (spot == -1 && i < 16)
                    {
                        spot = i;
                    }
                }
            }
            if (spot == -1)
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                return;
            }
            Peripheral newP = new Peripheral(handler, split[2], spot);
            buf = System.Text.Encoding.UTF8.GetBytes("CPU:" + spot.ToString());
            handler.Send(buf);
            Peripherals.Insert(spot, newP);
        }
    }
}
