using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
namespace NK4VM2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }

    public class Peripheral
    {

        public Socket socket { get; set; }
        public string name { get; set; }
        public int num { get; set; }

        public Peripheral()
        {

        }

        public Peripheral(Socket Socket, string Name, int Num)
        {
            socket = Socket;
            name = Name;
            num = Num;
        }

        public override string ToString()
        {
            return num.ToString() + ":" + name;
        }
    }
}
